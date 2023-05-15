using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using NUnit.Framework.Constraints;

namespace BackToTheCheckout;

public class Tests
{
    [TestCase(50,50,1,3,20 )]
    [TestCase(100,50,2,3,20)]
    [TestCase(130,50,3,3,20)]
    [TestCase(180,50,4,3,20)]
    [TestCase(230,50,5,3,20)]
    [TestCase(260,50,6,3,20)]
    public void GivenInputIsAs_ReturnPriceAsExpected(int expectedTotalPrice, int priceOfA, int numberOfA, int discountRuleForA, int discountValueForA)
    {
        //Arrange
        var checkout = new Checkout();  
        
        //Act
        int totalPrice = checkout.CalculateTotalPrice(numberOfA, priceOfA, discountRuleForA, discountValueForA);
        
        //Assert
        Assert.AreEqual(expectedTotalPrice, totalPrice);
    }

    [TestCase(50,50,1,3,20,30,0,2,15)]
    [TestCase(80, 50, 1, 3, 20, 30, 1, 2, 15)]
    [TestCase(175,50,3,3,20,30,2,2,15)]
    [TestCase(290, 50, 6, 3, 20, 30, 1, 2, 15)]
    [TestCase(305,50,6,3,20,30,2,2,15)]
    public void GivenInputIsAAndBs_ReturnPriceAsExpected(int expectedTotalPrice, int priceOfA, int numberOfA, int discountRuleForA, int discountValueForA, int priceOfB, int numberOfB, int discountRuleForB, int discountValueForB)
    {
        //Arrange
        var checkout = new Checkout();  
        
        //Act
        int totalPrice = checkout.CalculateTotalPrice(numberOfA, priceOfA, discountRuleForA, discountValueForA,numberOfB,priceOfB,discountRuleForB,discountValueForB);
        
        //Assert
        Assert.AreEqual(expectedTotalPrice, totalPrice);
    }
    
    // [TestCase(70,50,1,3,20,30,0,2,15, 20, 1)]
    // [TestCase(100, 50, 1, 3, 20, 30, 1, 2, 15, 20, 1)]
    // [TestCase(195, 50, 3, 3, 20, 30, 2, 2, 15, 20, 1)]
    // [TestCase(215, 50, 3, 3, 20, 30, 2, 2, 15, 20, 2)]
    // public void GivenInputIsABCs_ReturnPriceAsExpected(int expectedTotalPrice, int priceOfA, int numberOfA, int discountRuleForA, int discountValueForA, int priceOfB, int numberOfB, int discountRuleForB, int discountValueForB, int priceOfC, int numberOfC)
    // {
    //     //Arrange
    //     var checkout = new Checkout();  
    //     
    //     //Act
    //     int totalPrice = checkout.CalculateTotalPrice(numberOfA, priceOfA, discountRuleForA, discountValueForA,numberOfB,priceOfB,discountRuleForB,discountValueForB, priceOfC, numberOfC);
    //     
    //     //Assert
    //     Assert.AreEqual(expectedTotalPrice, totalPrice);
    // }
    
    [TestCase(50,50,1,3,20,30,0,2,15)]
    [TestCase(80, 50, 1, 3, 20, 30, 1, 2, 15)]
    [TestCase(175,50,3,3,20,30,2,2,15)]
    [TestCase(290, 50, 6, 3, 20, 30, 1, 2, 15)]
    [TestCase(305,50,6,3,20,30,2,2,15)]
    public void GivenInputs_ReturnPriceAsExpected(int expectedTotalPrice, int priceOfA, int numberOfA, int discountRuleForA, int discountValueForA, int priceOfB, int numberOfB, int discountRuleForB, int discountValueForB)
    {
        //Arrange
        var checkout = new Checkout();
        var list = new List<KeyValuePair<string, int>>();
        //Act
        list.Add(new KeyValuePair<string, int>("A",1));
        int totalPrice = checkout.CalculateTotalPrice(numberOfA, priceOfA, discountRuleForA, discountValueForA,numberOfB,priceOfB,discountRuleForB,discountValueForB);
        
        //Assert
        Assert.AreEqual(expectedTotalPrice, totalPrice);
    }

    [TestCase("AAABBC", 195)]
    [TestCase("A",50)]
    [TestCase("AB",80)]
    [TestCase("AAAA",180)]
    [TestCase("AAAAAA",260)]
    [TestCase("AAABBD",190)]
    [TestCase("DABABA",190)]
    [TestCase("CDBA",115)]
    public void CalculateTotalPriceFinalImplementation(string input, int expectedCost)
    {
        //Arrange
        var checkout = new Checkout();
        
        //Act
        int totalPrice = checkout.NewImplementation(input, new Rules(50, 30, 20, 15, 3, 20, 2, 15));
        
        //Assert
        Assert.AreEqual(expectedCost, totalPrice);

    }
}




