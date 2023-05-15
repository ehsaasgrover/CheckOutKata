using System.Runtime.InteropServices.JavaScript;

namespace BackToTheCheckout;

public class Tests
{
    public Tests()
    {
    }

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
    
    [TestCase(70,50,1,3,20,30,0,2,15, 20, 1)]
    [TestCase(100, 50, 1, 3, 20, 30, 1, 2, 15, 20, 1)]
    [TestCase(195, 50, 3, 3, 20, 30, 2, 2, 15, 20, 1)]
    [TestCase(215, 50, 3, 3, 20, 30, 2, 2, 15, 20, 2)]
    public void GivenInputIsABCs_ReturnPriceAsExpected(int expectedTotalPrice, int priceOfA, int numberOfA, int discountRuleForA, int discountValueForA, int priceOfB, int numberOfB, int discountRuleForB, int discountValueForB, int priceOfC, int numberOfC)
    {
        //Arrange
        var checkout = new Checkout();  
        
        //Act
        int totalPrice = checkout.CalculateTotalPrice(numberOfA, priceOfA, discountRuleForA, discountValueForA,numberOfB,priceOfB,discountRuleForB,discountValueForB, priceOfC, numberOfC);
        
        //Assert
        Assert.AreEqual(expectedTotalPrice, totalPrice);
    }
}




