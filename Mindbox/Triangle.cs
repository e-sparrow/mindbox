namespace Mindbox
{
    internal sealed class Triangle
        : IShape<double>
    {
        public Triangle(double side1, double side2, double side3)
        {
            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }

        private readonly double _side1;
        private readonly double _side2;
        private readonly double _side3;
        
        public double CalculateArea()
        {
            var isRectangular = IsRectangularTriangle(out var rectangularTriangle);
            if (isRectangular)
            {
                return rectangularTriangle.CalculateArea();
            }
            
            var isRight = IsRightTriangle(out var rightTriangle);
            if (isRight)
            {
                return rightTriangle.CalculateArea();
            }

            var isIsosceles = IsIsoscelesTriangle(out var isoscelesTriangle);
            if (isIsosceles)
            {
                return isoscelesTriangle.CalculateArea();
            }

            var result = MathHelper.UseHeronFormula(_side1, _side2, _side3);
            return result;
        }

        private bool IsRightTriangle(out RightTriangle result)
        {
            const double tolerance = 0.001d;

            result = null;
            
            var isRight = 
                Math.Abs(_side1 - _side2) < tolerance && 
                Math.Abs(_side2 - _side3) < tolerance && 
                Math.Abs(_side3 - _side1) < tolerance;

            if (isRight)
            {
                result = new RightTriangle(_side1);
            }

            return isRight;
        }
        
        private bool IsRectangularTriangle(out RectangularTriangle result)
        {
            const double tolerance = 0.001d;
            
            result = null;

            var array = new double[3]
            {
                _side1,
                _side2,
                _side3
            };
            
            Array.Sort(array);

            var isRectangular = Math.Pow(array[2], 2) == Math.Pow(array[0], 2) + Math.Pow(array[1], 2);
            if (isRectangular)
            {
                result = new RectangularTriangle(array[0], array[1]);
            }

            return isRectangular;
        }

        private bool IsIsoscelesTriangle(out IsoscelesTriangle result)
        {
            const double tolerance = 0.01d;

            result = null;
            
            if (Math.Abs(_side1 - _side2) < tolerance)
            {
                result = new IsoscelesTriangle(_side1, _side3);
                return true;
            }

            if (Math.Abs(_side2 - _side3) < tolerance)
            {
                result = new IsoscelesTriangle(_side2, _side1);
                return true;
            }

            if (Math.Abs(_side3 - _side1) < tolerance)
            {
                result = new IsoscelesTriangle(_side3, _side2);
                return true;
            }

            return false;
        }

        private sealed class RightTriangle
            : IShape<double>
        {
            public RightTriangle(double side)
            {
                _side = side;
            }

            private readonly double _side;
            
            public double CalculateArea()
            {
                var result = Math.Sqrt(3) * Math.Pow(_side, 2) / 4;
                return result;
            }
        }

        private sealed class RectangularTriangle
            : IShape<double>
        {
            public RectangularTriangle(double cathetus1, double cathetus2)
            {
                _cathetus1 = cathetus1;
                _cathetus2 = cathetus2;
            }

            private readonly double _cathetus1;
            private readonly double _cathetus2;
            
            public double CalculateArea()
            {
                var result = _cathetus1 * _cathetus2 / 2;
                return result;
            }
        }

        private sealed class IsoscelesTriangle
            : IShape<double>
        {
            public IsoscelesTriangle(double equalSides, double baseSide)
            {
                _equalSides = equalSides;
                _baseSide = baseSide;
            }

            private readonly double _equalSides;
            private readonly double _baseSide;
            
            public double CalculateArea()
            {
                var result = _baseSide / 4 * Math.Sqrt(4 * Math.Pow(_equalSides, 2) - Math.Pow(_baseSide, 2));
                return result;
            }
        }
    }
}
