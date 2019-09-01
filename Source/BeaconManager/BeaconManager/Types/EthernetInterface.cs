using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BeaconManager.Types
{
    public class EthernetInterface
    {
        public String Text;
        public UnicastIPAddressInformation IP;

        public EthernetInterface(String text, UnicastIPAddressInformation ip)
        {
            Text = text;
            IP = ip;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
