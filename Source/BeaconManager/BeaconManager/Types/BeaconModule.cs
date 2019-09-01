using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeaconManager.Types
{
    public delegate void OnModuleStatusChanged(BeaconModule module);

    public class BeaconModule
    {
        private IPAddress IP;
        private String UUID;
        private Boolean Status;

        public event OnModuleStatusChanged OnModuleStatusChanged;
        
        public BeaconModule(IPAddress ip, String uuid)
        {
            IP = ip;
            UUID = uuid;
        }

        public async Task LoadStatus()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync($"http://{IP}:5000/status"))
                {
                    try
                    {
                        response.EnsureSuccessStatusCode();
                        String json = await response.Content.ReadAsStringAsync();
                        Boolean status = ((JObject) JsonConvert.DeserializeObject(json))["status"].ToObject<Int32>() ==
                                         1;
                        if (Status != status)
                        {
                            OnModuleStatusChanged?.Invoke(this);
                        }

                        Status = status;
                    }
                    catch (HttpRequestException)
                    {

                    }
                }
            }
        }

        public IPAddress GetIP()
        {
            return IP;
        }

        public String GetUUID()
        {
            return UUID;
        }

        public async Task<Boolean> GetStatus()
        {
            await LoadStatus();
            return Status;
        }

        public Boolean GetStatusCache()
        {
            return Status;
        }

        public async Task Start()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync($"http://{IP}:5000/start"))
                {
                    try
                    {
                        response.EnsureSuccessStatusCode();
                        if (Status == false)
                        {
                            Status = true;
                            OnModuleStatusChanged?.Invoke(this);
                        }
                    }
                    catch (HttpRequestException)
                    {

                    }
                }
            }
        }

        public async Task Stop()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync($"http://{IP}:5000/stop"))
                {
                    try
                    {
                        response.EnsureSuccessStatusCode();
                        if (Status)
                        {
                            Status = false;
                            OnModuleStatusChanged?.Invoke(this);
                        }
                    }
                    catch (HttpRequestException)
                    {

                    }
                }
            }
        }

        public async Task ClearData()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync($"http://{IP}:5000/scan"))
                {
                    try
                    {
                        response.EnsureSuccessStatusCode();
                    }
                    catch (HttpRequestException)
                    {

                    }
                }
            }
        }

        public async Task<List<Beacon>> GetData()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync($"http://{IP}:5000/scan"))
                {
                    try
                    {
                        response.EnsureSuccessStatusCode();
                        String json = await response.Content.ReadAsStringAsync();

                        List<Beacon> list = new List<Beacon>();
                        List<RawBeacon> rawList = JsonConvert.DeserializeObject<List<RawBeacon>>(json);
                        foreach (RawBeacon rawBeacon in rawList)
                        {
                            UInt16 major = Convert.ToUInt16(rawBeacon.Major, 16);
                            UInt16 minor = Convert.ToUInt16(rawBeacon.Minor, 16);
                            Int16 defRssi = Convert.ToInt16(rawBeacon.DefRSSI);
                            Int32 rssi = Convert.ToInt32(rawBeacon.RSSI);

                            Console.WriteLine(rawBeacon.Mac);
                            try
                            {
                                Beacon dummyBeacon = new Beacon(Guid.Parse(rawBeacon.Mac).ToString("D").ToUpper(),
                                    major, minor, defRssi);

                                if (list.Contains(dummyBeacon))
                                {
                                    Int32 index = list.IndexOf(dummyBeacon);
                                    list[index].AddData(rawBeacon.Time, rssi);
                                }
                                else
                                {
                                    dummyBeacon.AddData(rawBeacon.Time, rssi);
                                    list.Add(dummyBeacon);
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }

                        return list;
                    }
                    catch (HttpRequestException)
                    {
                        return new List<Beacon>();
                    }
                }
            }
        }

        public static async Task<BeaconModule> GetBeacon(IPAddress ip, int port = 5000, int tcpTimeout = 1000)
        {
            using (TcpClient client = new TcpClient())
            {
                var result = client.BeginConnect(ip.ToString(), port, null, null);
                var success = result.AsyncWaitHandle.WaitOne(tcpTimeout);
                if (!success)
                {
                    return null;
                }
            }

            String uuid;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync($"http://{ip.ToString()}:5000/info"))
                {
                    try
                    {
                        response.EnsureSuccessStatusCode();
                        String uuid_raw = await response.Content.ReadAsStringAsync();
                        uuid = Guid.Parse(((JObject)JsonConvert.DeserializeObject(uuid_raw))["UUID"].ToString()).ToString("D").ToUpper();
                    }
                    catch (HttpRequestException)
                    {
                        return null;
                    }
                }
            }

            BeaconModule module = new BeaconModule(ip, uuid);
            await module.LoadStatus();

            return module;
        } 
    }
}
