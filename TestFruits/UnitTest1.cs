namespace TestFruits
{
    using System;
    using Xunit;

    public class FruitTests
    {
        [Fact]
        public void FruitConstructor_SetsNameAndColor()
        {
         
            var fruit = new Fruit("Apple", "Red");

     
            Assert.Equal("Apple", fruit.Name);
            Assert.Equal("Red", fruit.Color);
        }

        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
           
            var fruit = new Fruit("Banana", "Yellow");

         
            var result = fruit.ToString();

         
            Assert.Equal("Fruit: Banana, Color: Yellow", result);
        }
    }

    public class CitrusTests
    {
        [Fact]
        public void CitrusConstructor_SetsNameColorAndVitaminC()
        {
         
            var citrus = new Citrus("Lemon", "Yellow", 53);

        
            Assert.Equal("Lemon", citrus.Name);
            Assert.Equal("Yellow", citrus.Color);
            Assert.Equal(53, citrus.VitaminC);
        }

        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
         
            var citrus = new Citrus("Orange", "Orange", 70);

          
            var result = citrus.ToString();

          
            Assert.Equal("Fruit: Orange, Color: Orange", result);
        }

 
    }



}