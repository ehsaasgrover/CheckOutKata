using System.Runtime.InteropServices.JavaScript;

namespace BackToTheCheckout;

public class Tests
{
    [TestCase(50,50,1,3,20 )]
    [TestCase(100,50,2,3,20)]
    [TestCase(130,50,3,3,20)]
    public void GivenInputIsANumberOfAs_ReturnPriceAsExpected(int expectedTotalPrice,int priceOfA, int numberOfA, int discountRuleForA, int discountValueForA)
    {
        //Arrange
        var checkout = new Checkout();  
        
        //Act
        int totalPrice = checkout.CalculateTotalPrice(numberOfA, priceOfA, discountRuleForA, discountValueForA);
        
        //Assert
        Assert.AreEqual(expectedTotalPrice, totalPrice);
    }
}




