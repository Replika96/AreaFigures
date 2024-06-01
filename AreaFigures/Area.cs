namespace AreaFigures
{
    public interface IShape // Вычисление площади фигуры без знания типа фигуры в compile-time и легкость добавления других фигур путем реализации интерфейса
    {
        double CalcArea();
    }
    public class Circle : IShape
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            if (radius < 0) throw new Exception("Радиус должен быть больше 0");
            Radius = radius;
        }
        public double CalcArea() { return Math.PI * Math.Pow(Radius,2); }
    }
    public class Triangle : IShape
    {
        public double sideA { get; }
        public double sideB { get; }
        public double sideC { get; }
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Все стороны должны быть больше 0");
            }

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentException("Сумма двух любых сторон должна быть больше третей");
            }
            this.sideC = sideC;
            this.sideA = sideA;
            this.sideB = sideB;
        }
        public double CalcArea()
        {
            double p = (sideC+sideA+sideB)/2;
            return Math.Sqrt(p*(p-sideB)*(p-sideA)*(p-sideC));
        }
        public bool IsRightTriangle() // Проверку на то, является ли треугольник прямоугольным 
        {
            double[] a = [sideA,sideB,sideC];
            Array.Sort(a);
            return (a[2] * a[2]) == (a[1] * a[1] + a[0] * a[0]);
        }
    }
    public static class ShapeAreaCalculator 
    {
        public static double CalculateArea(IShape shape)
        {
            return shape.CalcArea();
        }
    }
}
