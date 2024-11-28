namespace Mindbox
{
    public static class ShapeProvider
    {
        public static bool TryCreateTriangle(double side1, double side2, double side3, out IShape<double> result)
        {
            result = null;
            
            var isValid = side1 + side2 > side3 || side2 + side3 > side1 || side3 + side1 > side2;
            if (isValid)
            {
                result = new Triangle(side1, side2, side3);
            }

            return isValid;
        }

        public static IShape<double> CreateCircle(double radius)
        {
            var result = new Circle(radius);
            return result;
        }
    }
}