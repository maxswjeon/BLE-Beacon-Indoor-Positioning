using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BeaconManager.Forms;
using BeaconManager.Types;

namespace BeaconManager.Utilities
{
    public class NetworkManager
    {
        public static List<EthernetInterface> GetEthernetInterfaces(Boolean getUnavailable)
        {
            List<EthernetInterface> items = new List<EthernetInterface>();

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus != OperationalStatus.Up && !getUnavailable)
                {
                    continue;
                }

                foreach (var ip in nic.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        items.Add(new EthernetInterface($"{nic.Description} ({ip.Address.ToString()})", ip));
                    }
                }
            }

            return items;
        }

        public static IPAddress NextAddress(IPAddress ip)
        {
            Byte[] ipBytes = ip.GetAddressBytes();
            for (int i = ipBytes.Length - 1; i >= 0; --i)
            {
                if (ipBytes[i] + 1 < 256)
                {
                    ipBytes[i] += 1;
                    break;
                }

                ipBytes[i] = 0;
                ipBytes[i - 1] += 1;
            }

            return new IPAddress(ipBytes);
        }

        public static (IPAddress start, IPAddress end, int count) GetSubnetRange(IPAddress host, IPAddress mask)
        {
            Byte[] hostBytes = host.GetAddressBytes();
            Byte[] maskBytes = mask.GetAddressBytes();

            Byte[] startBytes = new Byte[hostBytes.Length];
            Byte[] endBytes = new Byte[hostBytes.Length];

            for (int i = 0; i < hostBytes.Length; ++i)
            {
                startBytes[i] = (Byte)(hostBytes[i] & maskBytes[i]);
                endBytes[i] = (Byte)(hostBytes[i] | ~maskBytes[i]);
            }

            //Skip Network Address
            startBytes[hostBytes.Length - 1] += 1;

            IPAddress startIP = new IPAddress(startBytes);
            IPAddress endIP = new IPAddress(endBytes);

            Array.Reverse(startBytes);
            Array.Reverse(endBytes);

            int count = (int) (BitConverter.ToUInt32(endBytes, 0)
                               - BitConverter.ToUInt32(startBytes, 0));

            return (startIP, endIP, count);
        }
    }
}
