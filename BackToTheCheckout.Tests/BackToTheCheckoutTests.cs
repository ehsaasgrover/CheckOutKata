using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using NUnit.Framework.Constraints;

namespace BackToTheCheckout;
// Test to check the prices are calculated as expected
public class Tests
{
    // Test to check the total prices are calculated properly with valid inputs
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
    public void GivenInputHasMultipleValuesAndIsValid_ReturnTotalPriceAsExpected(string input, int expectedCost)
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        int totalPrice = checkout.CalculateTotalPrice(input);
        
        //Assert
        Assert.That(totalPrice, Is.EqualTo(expectedCost));

    }
    
    // Test to check the total prices are calculated properly with different rules
    [TestCase("",0)]
    [TestCase("AAA",105)]
    [TestCase("AAABBC",165)]
    public void GivenInputHasMultipleValuesAndIsValidWithDifferentRules_ReturnTotalPriceAsExpected(string input, int expectedCost)
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
    public void GivenInputHasMultipleValuesAndIsNotValid_ThrowAnException(string invalidInput)
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => checkout.CalculateTotalPrice(invalidInput));
    }
    
    
    
    // Test to check the incremental price is calculated as expected
    [Test]
    public void GivenInputIsIncrementalAndIsValid_ReturnTotalPriceAsExpected()
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        int totalPrice = checkout.Scan("A");
        totalPrice = checkout.Scan("A");
        totalPrice = checkout.Scan("A");
        totalPrice = checkout.Scan("B");
        totalPrice = checkout.Scan("B");
        totalPrice = checkout.Scan("D");

        //Assert
        Assert.That(totalPrice, Is.EqualTo(190));
    }
    
    // Test to check the incremental price is calculated as expected with different rules
    [Test]
    public void GivenInputIsIncrementalAndIsValidWithDifferentRules_ReturnTotalPriceAsExpected()
    {
        //Arrange
        var checkout = new Checkout(new Rules(40, 20, 20, 15, 2, 15, 3, 20));
        
        //Act
        int totalPrice = checkout.Scan("A");
        totalPrice = checkout.Scan("A");
        totalPrice = checkout.Scan("A");
        totalPrice = checkout.Scan("B");
        totalPrice = checkout.Scan("B");
        totalPrice = checkout.Scan("C");

        //Assert
        Assert.That(totalPrice, Is.EqualTo(165));
    }
    
    // Test to check the scan method throws an invalid argument exception 
    [TestCase("X")]
    [TestCase("2")]
    public void GivenInputIsIncrementalAndIsNotValid_ThrowAnException(string invalidInput)
    {
        //Arrange
        var checkout = new Checkout(new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => checkout.Scan(invalidInput));
    }
}




