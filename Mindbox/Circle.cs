namespace Mindbox
{
    internal sealed class Circle
        : IShape<double>
    {
        public Circle(double radius)
        {
            _radius = radius;
        }

        private readonly double _radius;

        public double CalculateArea()
        {
            var result = Math.PI * Math.Pow(_radius, 2);
            return result;
        }
    }
}
