using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using NUnit.Framework.Constraints;

namespace BackToTheCheckout;

public class Tests
{
    [TestCase("AAABBC", 195)]
    [TestCase("A",50)]
    [TestCase("AB",80)]
    [TestCase("AAAA",180)]
    [TestCase("AAAAAA",260)]
    [TestCase("AAABBD",190)]
    [TestCase("DABABA",190)]
    [TestCase("CDBA",115)]
    public void GivenInputIsMultipleValues_ReturnPriceAsExpected(string input, int expectedCost)
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        int totalPrice = checkout.CalculateTotalPrice(input);
        
        //Assert
        Assert.AreEqual(expectedCost, totalPrice);

    }

    [TestCase("A",50)]
    public void GivenInputIsIncremental_ReturnPriceAsExpected(string input, int expectedCost)
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        int totalPrice = checkout.Scan(input);

        //Assert
        Assert.AreEqual(expectedCost, totalPrice);
    }
    
    
}




