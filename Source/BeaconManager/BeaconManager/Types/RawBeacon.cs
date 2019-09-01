using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BeaconManager.Types
{
    class RawBeacon
    {
        [JsonProperty("mac")]
        public String Mac;

        [JsonProperty("major")]
        public String Major;

        [JsonProperty("minor")]
        public String Minor;

        [JsonProperty("txpower")]
        public String DefRSSI;

        [JsonProperty("rssi")]
        public String RSSI;

        [JsonProperty("time")]
        public Double Time;
    }
}
