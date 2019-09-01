using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconManager.Types
{
    public class Beacon
    {
        public readonly String UUID;
        public readonly UInt16 Major;
        public readonly UInt16 Minor;
        public readonly Int16 DefRSSI;

        private List<Tuple<DateTime, Int32>> RSSIList;

        public Beacon(String uuid, UInt16 major, UInt16 minor, Int16 defRSSI)
        {
            RSSIList = new List<Tuple<DateTime, Int32>>();
            UUID = uuid;
            Major = major;
            Minor = minor;
            DefRSSI = defRSSI;
        }

        public void AddData(Double time, Int32 rssi)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            RSSIList.Add(new Tuple<DateTime, Int32>(dtDateTime.AddMilliseconds(time * 1000), rssi));
            RSSIList.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        }

        public List<Tuple<DateTime, Int32>> GetData()
        {
            return RSSIList;
        }
        public override bool Equals(object other)
        {
            return this.Equals(other as Beacon);
        }

        protected bool Equals(Beacon other)
        {
            return string.Equals(UUID, other.UUID, StringComparison.OrdinalIgnoreCase) && Major == other.Major && Minor == other.Minor;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (UUID != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(UUID) : 0);
                hashCode = (hashCode * 397) ^ Major.GetHashCode();
                hashCode = (hashCode * 397) ^ Minor.GetHashCode();
                return hashCode;
            }
        }
    }
}
