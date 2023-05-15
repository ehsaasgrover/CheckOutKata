using System.Runtime.InteropServices.JavaScript;

namespace BackToTheCheckout;

public class Tests
{
    [TestCase(50,50,1)]
    [TestCase(100,50,2)]
    [TestCase(130,50,3)]
    public void GivenInputIsANumberOfAs_ReturnPriceAsExpected(int expectedTotalPrice,int priceOfA, int numberOfA)
    {
        //Arrange
        var checkout = new Checkout();
        
        //Act
        int totalPrice = checkout.CalculateTotalPrice(numberOfA, priceOfA);
        
        //Assert
        Assert.AreEqual(expectedTotalPrice, totalPrice);
    }
}




