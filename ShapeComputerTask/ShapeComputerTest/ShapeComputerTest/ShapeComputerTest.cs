using System;
using Xunit;
using ShapeComputer;

namespace ShapeComputerTest
{
    public class ShapeComputerTest
    {
        [Fact]
        public void RightTriangleTest()
        {
            var rightTriangle = new RightTriangle(3, 4, 5);
            var expectedResult = 6;

            var result = rightTriangle.Square;

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void RadiusComputingTest()
        {
            var circle = new Circle(3);

            var expectedResult = 28.2743;

            var result = circle.Square;

            Assert.Equal(expectedResult, Math.Round(result, 4));
        }
    }
}
