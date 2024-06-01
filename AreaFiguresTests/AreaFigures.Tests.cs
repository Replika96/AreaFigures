using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaFigures.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void GetArea_WithValidRadius_ShouldReturnCorrectArea()
        {
            double radius = 5;
            Circle circle = new Circle(radius);
            double expectedArea = Math.PI * Math.Pow(radius, 2);
            double actualArea = circle.CalcArea();
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNonPositiveRadius_ShouldThrowException()
        {
            new Circle(-1);
        }
    }
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        public void TriangleTest()
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            double expectedArea = 6;
            double actualArea = triangle.CalcArea();
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithInvalidSides_ShouldThrowArgumentException()
        {
            new Triangle(1, 1, 3);
        }

        [TestMethod()]
        public void IsRightAngled_WithNonRightAngledTriangle_ShouldReturnFalse()
        {
            Triangle triangle = new Triangle(3, 4, 6);
            bool isRight = triangle.IsRightTriangle();
            Assert.IsFalse(isRight);
        }
    }
    [TestClass()]
    public class ShapeAreaCalculatorTests
    {
        [TestMethod()]
        public void CalculateArea_WithCircle_ShouldReturnCorrectArea()
        {
            IShape circle = new Circle(11);
            double expectedArea = Math.PI * 121;
            double actualArea = ShapeAreaCalculator.CalculateArea(circle);
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestMethod()]
        public void CalculateArea_WithTriangle_ShouldReturnCorrectArea()
        {
            IShape triangle = new Triangle(3, 4, 5);
            double expectedArea = 6;
            double actualArea = ShapeAreaCalculator.CalculateArea(triangle);
            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}