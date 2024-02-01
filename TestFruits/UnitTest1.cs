namespace TestFruits
{
    using System;
    using Xunit;

    public class FruitTests
    {
        [Fact]
        public void FruitConstructor_SetsNameAndColor()
        {
            // Arrange & Act
            var fruit = new Fruit("Apple", "Red");

            // Assert
            Assert.Equal("Apple", fruit.Name);
            Assert.Equal("Red", fruit.Color);
        }

        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var fruit = new Fruit("Banana", "Yellow");

            // Act
            var result = fruit.ToString();

            // Assert
            Assert.Equal("Fruit: Banana, Color: Yellow", result);
        }
    }

    public class CitrusTests
    {
        [Fact]
        public void CitrusConstructor_SetsNameColorAndVitaminC()
        {
            // Arrange & Act
            var citrus = new Citrus("Lemon", "Yellow", 53);

            // Assert
            Assert.Equal("Lemon", citrus.Name);
            Assert.Equal("Yellow", citrus.Color);
            Assert.Equal(53, citrus.VitaminC);
        }

        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var citrus = new Citrus("Orange", "Orange", 70);

            // Act
            var result = citrus.ToString();

            // Assert
            Assert.Equal("Fruit: Orange, Color: Orange", result);
        }

        // More tests can be added to cover Input and Print methods.
        // These methods require mocking the console input/output,
        // which can be done using the System.IO.Abstractions package or similar.
    }

    // To run these tests, you would use the Test Explorer in Visual Studio
    // or run the `dotnet test` command in your terminal within the test project directory.

}