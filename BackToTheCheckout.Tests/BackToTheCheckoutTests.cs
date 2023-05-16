using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using NUnit.Framework.Constraints;

namespace BackToTheCheckout;
// Test to check the prices are calculated as expected
public class Tests
{
    // Test Cases to check the total prices are calculated properly
    [TestCase("",0)]
    [TestCase("AAABBC", 195)]
    [TestCase("A",50)]
    [TestCase("AB",80)]
    [TestCase("AAAA",180)]
    [TestCase("AAAAAA",260)]
    [TestCase("AAABBD",190)]
    [TestCase("DABABA",190)]
    [TestCase("CDBA",115)]
    [TestCase("AAABBCDC",230)]
    public void GivenInputIsMultipleValuesAndValid_ReturnTotalPriceAsExpected(string input, int expectedCost)
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        int totalPrice = checkout.CalculateTotalPrice(input);
        
        //Assert
        Assert.That(totalPrice, Is.EqualTo(expectedCost));

    }
    
    // Test Cases to check the total prices are calculated properly
    [TestCase("",0)]
    [TestCase("AAA",105)]
    [TestCase("AAABBC",165)]
    public void GivenInputIsMultipleValuesAndValidWithDifferentRules_ReturnTotalPriceAsExpected(string input, int expectedCost)
    {
        //Arrange
        var checkout = new Checkout(new Rules(40, 20, 20, 15, 2, 15, 3, 20));
        
        //Act
        int totalPrice = checkout.CalculateTotalPrice(input);
        
        //Assert
        Assert.That(totalPrice, Is.EqualTo(expectedCost));
    }
    
    // Test for invalid arguments when calculating the total price
    [TestCase("ABE")]
    [TestCase("X")]
    [TestCase("AAB123BCCD")]
    [TestCase("123")]
    [TestCase("AB2C")]
    public void GivenInputOfMultipleValuesIsNotValid_ThrowAnException(string invalidInput)
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => checkout.CalculateTotalPrice(invalidInput));
    }
    
    
    // Test Cases to check the incremental price is calculated as expected
    [TestCase("A",50)]
    [TestCase("",0)]
    public void GivenInputIsIncrementalAndValid_ReturnTotalPriceAsExpected(string input, int expectedCost)
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        int totalPrice = checkout.Scan(input);

        //Assert
        Assert.That(totalPrice, Is.EqualTo(expectedCost));
    }

    [TestCase("X")]
    [TestCase("2")]
    public void GivenInputIsIncrementalAndInvalid_ThrowAnException(string invalidInput)
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => checkout.Scan(invalidInput));
    }
}




