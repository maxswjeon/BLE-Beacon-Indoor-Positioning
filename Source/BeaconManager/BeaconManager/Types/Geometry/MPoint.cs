using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconManager.Types.Geometry
{
    public class MPoint
    {
        public double X;
        public double Y;

        public MPoint(Point point)
        {
            X = point.X;
            Y = point.Y;
        } 

        public MPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static MPoint operator +(MPoint p1, MPoint p2)
        {
            return new MPoint(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static MPoint operator -(MPoint p1, MPoint p2)
        {
            return new MPoint(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static MPoint operator *(MPoint p, double a)
        {
            return new MPoint(p.X * a, p.Y * a);
        }
        public static MPoint operator /(MPoint p, double a)
        {
            return new MPoint(p.X / a, p.Y / a);
        }

        public static MPoint operator -(MPoint p)
        {
            return new MPoint(-p.X, -p.Y);
        }

        public static explicit operator Point(MPoint p)
        {
            return new Point((int)p.X, (int)p.Y);
        }

        public static implicit operator MPoint(Point p)
        {
            return new MPoint(p);
        }

        public static double Distance(MPoint p1, MPoint p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MPoint) obj);
        }

        protected bool Equals(MPoint other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static bool operator ==(MPoint left, MPoint right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MPoint left, MPoint right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $@"({X}, {Y})";
        }

    }
}
