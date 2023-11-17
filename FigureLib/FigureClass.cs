namespace FigureLib
{
    public abstract class Shape
    {
        public abstract double Area();
    }
    public class Circle : Shape
    {
        double radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }
        public override double Area() => Math.PI * radius * radius;
    }
    public class Triangle : Shape
    {
        private readonly double firstSide;
        private readonly double secondSide;
        private readonly double thirdSide;
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if (!double.IsNormal(firstSide) || firstSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(firstSide), "Должно быть положительное число.");
            if (!double.IsNormal(secondSide) || secondSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(secondSide), "Должно быть положительное число.");
            if (!double.IsNormal(thirdSide) || thirdSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(thirdSide), "Должно быть положительное число.");
            this.firstSide = firstSide;
            this.secondSide = secondSide;
            this.thirdSide = thirdSide;
        }

        private double? area;
        public override double Area()
        {
            if (area is null)
            {
                double semiPerimeter = (firstSide + secondSide + thirdSide) / 2;
                double s = Math.Sqrt(semiPerimeter * (semiPerimeter - firstSide) * (semiPerimeter - secondSide) * (semiPerimeter - thirdSide));
                area = s;
            }
            return area.Value;
        }
        private bool? isExists;
        public bool IsExists
        {
            get
            {
                if (isExists is null)
                {
                    isExists = double.IsNormal(Area());
                }
                return isExists.Value;
            }
        }

        private bool? isRectangle;
        public bool IsRectangle
        {
            get
            {
                if (!IsExists)
                    return false;

                if (isRectangle is null)
                {
                    double a = firstSide, b = secondSide, c = thirdSide;
                    if (c < b)
                    {
                        (c, b) = (b, c);
                    }
                    if (c < a)
                    {
                        (c, a) = (a, c);
                    }
                    isRectangle = c * c == b * b + a * a;
                }
                return isRectangle.Value;
            }
        }
    }
}