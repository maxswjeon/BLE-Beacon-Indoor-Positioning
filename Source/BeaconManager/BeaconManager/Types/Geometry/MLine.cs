using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconManager.Types.Geometry
{
    public class MLine
    {
        public double M;
        public double B;

        public MLine(double m, double b)
        {
            M = m;
            B = b;
        }

        public MLine(double a, double b, double c)
        {
            M = -a / b;
            B = -c / b;
        }

        public MLine(double x1, double y1, double x2, double y2)
        {
            M = (y1 - y2) / (x1 - x2);
            B = y1 - M * x1;
        }

        public MLine(MPoint p1, MPoint p2)
        {
            M = (p1.Y - p2.Y) / (p1.X - p2.X);
            B = p1.Y - M * p1.X;
        }

        public MLine(MPoint p1, Point p2)
        {
            M = (p1.Y - p2.Y) / (p1.X - p2.X);
            B = p1.Y - M * p1.X;
        }

        public MLine(Point p1, MPoint p2)
        {
            M = (p1.Y - p2.Y) / (p1.X - p2.X);
            B = p1.Y - M * p1.X;
        }

        public MLine(Point p1, Point p2)
        {
            M = (double)(p1.Y - p2.Y) / (p1.X - p2.X);
            B = p1.Y - M * p1.X;
        }

        public static MPoint Intersect(MLine l1, MLine l2)
        {
            double x = (l2.B - l1.B) / (l1.M - l2.M);
            return new MPoint(x, l1.X(x));
        }

        public double X(double x)
        {
            return M * x + B;
        }

        public static MLine operator +(MLine l, MPoint p)
        {
            return new MLine(l.M, p.Y - l.M * p.X);
        }

        public static MLine operator -(MLine l, MPoint p)
        {
            return new MLine(l.M, -p.Y + l.M * p.X);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected bool Equals(MLine other)
        {
            return M.Equals(other.M) && B.Equals(other.B);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (M.GetHashCode() * 397) ^ B.GetHashCode();
            }
        }

        public static bool operator ==(MLine left, MLine right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MLine left, MLine right)
        {
            return !Equals(left, right);
        }
    }
}
