namespace ClassLibrary1
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    interface IPoint
    {
        double X { get; }
        double Y { get; }
        void SetCartesian(double x, double y);

        double R { get; }
        double Theta { get; }
        void SetPolar(double r, double theta);
    }
}