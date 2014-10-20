using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace LessonsSamples.Lesson5
{
        public class Line
        {
            private Point p1;
            private Point p2;
            public Line(Point p1, Point p2) { this.p1 = p1; this.p2 = p2; }
            public Point P1 { get { return p1; } }
            public Point P2 { get { return p2; } }
            public double Slope { get {/*code*/throw new NotImplementedException(); } }
            public double YIntercept { get {/*code*/throw new NotImplementedException(); } }
            public virtual bool IsOn(Point p) {/*code*/throw new NotImplementedException(); }
        }

        public class LineSegment : Line
        {
            public LineSegment(Point p1, Point p2) : base(p1, p2) { }
            public double Length { get {/*code*/throw new NotImplementedException(); } }
            public override bool IsOn(Point p) {/*code*/throw new NotImplementedException(); }
        }

        public abstract class LinearObject
        {
            private Point p1;
            private Point p2;
            public LinearObject(Point p1, Point p2)
            { this.p1 = p1; this.p2 = p2; }
            public Point P1 { get { return p1; } }
            public Point P2 { get { return p2; } }
            public abstract bool IsOn(Point p);
        }

        public class Line_ : LinearObject
        {
            public Line_(Point p1, Point p2) : base(p1, p2) { }
            public override bool IsOn(Point p) {/*code*/throw new NotImplementedException(); }
        }

        public class LineSegment_ : LinearObject
        {
            public LineSegment_(Point p1, Point p2) : base(p1, p2) { }
            public double GetLength() {/*code*/ throw new NotImplementedException();}
            public override bool IsOn(Point p) {/*code*/ throw new NotImplementedException(); }
        }

        public class Ray : LinearObject
        {
            public Ray(Point p1, Point p2) : base(p1, p2) {/*code*/}
            public override bool IsOn(Point p) {/*code*/throw new NotImplementedException(); }
        }

}
