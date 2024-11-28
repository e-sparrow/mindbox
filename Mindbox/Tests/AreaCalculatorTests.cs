namespace Mindbox.Tests
{
    // Все значения в словарях в тестах треугольников заполнены с помощью калькулятора площадей: https://calc.by/math-calculators/area-triangle.html
    [TestFixture]
    public sealed class AreaCalculatorTests
    {
        [Test]
        public void TestCircle()
        {
            var estimatedResults = new Dictionary<double, double>()
            {
                [1] = 3.141593,
                [2] = 12.566371,
                [3] = 28.274334,
                [4] = 50.265482
            };

            foreach (var (value, estimatedResult) in estimatedResults)
            {
                var tolerance = 0.001d;
                
                var circle = ShapeProvider.CreateCircle(value);
                var realResult = circle.CalculateArea();

                Assert.That(Math.Abs(realResult - estimatedResult) < tolerance);
            }
        }

        [Test]
        public void TestDefaultTriangle()
        {
            var estimatedResults = new Dictionary<(double, double, double), double>()
            {
                [(4, 6, 7)] = 11.97654,
                [(4, 2, 3)] = 2.904738,
                [(9, 8, 7)] = 26.832816
            };
            
            TestTriangle(estimatedResults);
        }

        [Test]
        public void TestRightTriangle()
        {
            var estimatedResults = new Dictionary<(double, double, double), double>()
            {
                [(3, 3, 3)] = 3.897114,
                [(5, 5, 5)] = 10.825318,
                [(10, 10, 10)] = 43.30127
            };

            TestTriangle(estimatedResults);
        }

        [Test]
        public void TestRectangularTriangle()
        {
            var estimatedResults = new Dictionary<(double, double, double), double>()
            {
                [(3, 4, 5)] = 6,
                [(6, 8, 10)] = 24,
                [(12, 16, 20)] = 96
            };

            TestTriangle(estimatedResults);
        }

        [Test]
        public void TestIsoscelesTriangle()
        {
            var estimatedResults = new Dictionary<(double, double, double), double>()
            {
                [(2, 2, 3)] = 1.984313,
                [(5, 5, 3)] = 7.154544,
                [(5, 8, 8)] = 18.998355
            };
            
            TestTriangle(estimatedResults);
        }

        private void TestTriangle(IDictionary<(double, double, double), double> estimatedResults)
        {
            foreach (var (value, estimatedResult) in estimatedResults)
            {
                var tolerance = 0.001d;
                
                var canCreate = ShapeProvider.TryCreateTriangle(value.Item1, value.Item2, value.Item3, out var triangle);
                if (canCreate)
                {
                    var realResult = triangle.CalculateArea();
                    Assert.That(Math.Abs(realResult - estimatedResult) < tolerance);
                }
                
                Assert.That(canCreate);
            }
        }
    }
}