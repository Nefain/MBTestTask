using FigureLib;

namespace xUnitMindBox
{
    public class UnitMindBox
    {
        [Fact]
        public void CircleAreaTest()
        {
            int r = 3;

            Shape circle = new Circle(r);

            Assert.Equal(9 * Math.PI, circle.Area());
        }

        [Fact]
        public void TriangleAreaTest()
        {
            int a = 3;
            int b = 4;
            int c = 5;

            Shape triangle = new Triangle(a, b, c);

            Assert.Equal(3 * 4 / 2, triangle.Area());
        }

        [Fact]
        public void TrianglePostiveNumberATest()
        {
            int a = -3;
            int b = 4;
            int c = 5;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
        }

        [Fact]
        public void TrianglePostiveNumberBTest()
        {
            int a = 3;
            int b = -4;
            int c = 5;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
        }

        [Fact]
        public void TrianglePostiveNumberCTest()
        {
            int a = 3;
            int b = 4;
            int c = -5;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
        }

        [Fact]
        public void TrianglePostiveNumberTest()
        {
            int a = -3;
            int b = -4;
            int c = -5;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
        }

        [Fact]
        public void TriangleIsExistTest()
        {
            int a = 3;
            int b = 4;
            int c = 5;

            Shape triangle = new Triangle(a, b, c);

            Assert.True(((Triangle)triangle).IsExists);
        }

        [Fact]
        public void TriangleDoesntExistTest()
        {
            int a = 1;
            int b = 100;
            int c = 1;

            Shape triangle = new Triangle(a, b, c);

            Assert.False(((Triangle)triangle).IsExists);
        }

        [Fact]
        public void TriangleIsRectangleTest()
        {
            int a = 3;
            int b = 4;
            int c = 5;

            Shape triangle = new Triangle(a, b, c);

            Assert.True(((Triangle)triangle).IsRectangle);
        }

        [Fact]
        public void TriangleNotRectangleTest()
        {
            int a = 3;
            int b = 4;
            int c = 4;

            Shape triangle = new Triangle(a, b, c);

            Assert.False(((Triangle)triangle).IsRectangle);
        }
    }
}