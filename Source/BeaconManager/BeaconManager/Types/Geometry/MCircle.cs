using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconManager.Types.Geometry
{
    public class MCircle
    {
        private MPoint Center { get; }
        private double Radius { get; }

        public MCircle(MPoint center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public MCircle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public Boolean onCircle(MPoint p)
        {
            return Math.Abs(MPoint.Distance(p, Center) - Radius) < Double.Epsilon;
        }

        public static MPoint IntersectThree(MCircle c1, MCircle c2, MCircle c3)
        {
            MPoint[] points = IntersectPoints(c1, c2);
            if (c3.onCircle(points[0]))
            {
                return points[0];
            }
            if (c3.onCircle(points[1]))
            {
                return points[1];
            }
            
            MLine[] lines = new MLine[2];
            lines[0] = IntersectLine(c1, c2);
            lines[1] = IntersectLine(c2, c3);
            
            return MLine.Intersect(lines[0], lines[1]);
        }

        public static MPoint[] IntersectPoints(MCircle c1, MCircle c2)
        {
            MPoint[] points = new MPoint[2];
            points[0] = new MPoint(Double.NaN, Double.NaN);
            points[1] = new MPoint(Double.NaN, Double.NaN);

            double d = MPoint.Distance(c1.Center, c2.Center);
            
            if (d > c1.Radius + c2.Radius)
            {
                return points;
            }

            if (d < Math.Abs(c1.Radius - c2.Radius))
            {
                return points;
            }

            if (Math.Abs(d) < Double.Epsilon && Math.Abs(c1.Radius - c2.Radius) < Double.Epsilon)
            {
                return points;
            }

            double a = (c1.Radius * c1.Radius - c2.Radius * c2.Radius + d * d) / 2 * d;
            double h = Math.Sqrt(c1.Radius * c1.Radius - a * a);

            MPoint p2 = c1.Center + (c1.Center - c2.Center) * a / d;

            points[0] = new MPoint(p2.X + h * (c2.Center.Y - c1.Center.Y) / d, p2.Y - h * (c2.Center.X - c1.Center.X) / d);
            points[1] = new MPoint(p2.X - h * (c2.Center.Y - c1.Center.Y) / d, p2.Y + h * (c2.Center.X - c1.Center.X) / d);
            return points;
        }

        public static MLine IntersectLine(MCircle c1, MCircle c2)
        {
            MPoint[] points = new MPoint[2];
            points[0] = new MPoint(Double.NaN, Double.NaN);
            points[1] = new MPoint(Double.NaN, Double.NaN);

            double d = MPoint.Distance(c1.Center, c2.Center);

            if (d > c1.Radius + c2.Radius)
            {
                return null;
            }

            if (d < Math.Abs(c1.Radius - c2.Radius))
            {
                return null;
            }

            if (Math.Abs(d) < Double.Epsilon && Math.Abs(c1.Radius - c2.Radius) < Double.Epsilon)
            {
                return null;
            }

            double a = (c1.Radius * c1.Radius - c2.Radius * c2.Radius + d * d) / 2 * d;
            double h = Math.Sqrt(c1.Radius * c1.Radius - a * a);

            MPoint p2 = c1.Center + (c1.Center - c2.Center) * a / d;

            points[0] = new MPoint(p2.X + h * (c2.Center.Y - c1.Center.Y) / d, p2.Y - h * (c2.Center.X - c1.Center.X) / d);
            points[1] = new MPoint(p2.X - h * (c2.Center.Y - c1.Center.Y) / d, p2.Y + h * (c2.Center.X - c1.Center.X) / d);
            return new MLine(points[0], points[1]);
        }
    }
}
