namespace Mindbox
{
    internal static class MathHelper
    {
        public static double UseHeronFormula(double side1, double side2, double side3)
        {
            var halfPerimeter = (side1 + side2 + side3) / 2;
            
            var result = Math.Sqrt(halfPerimeter * (halfPerimeter - side1) * (halfPerimeter - side2) * (halfPerimeter - side3));
            return result;
        }
    }
}