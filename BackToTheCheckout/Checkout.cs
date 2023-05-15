namespace BackToTheCheckout
{
    public class Checkout
    {
        public int CalculateTotalPrice(int numberOfA, int priceOfA, int discountRuleForA, int discountValueForA)
        {
            int totalPrice = numberOfA * priceOfA;
            if (numberOfA == discountRuleForA)
            {
                totalPrice -= discountValueForA;
            }

            return totalPrice;
        }
    }    
}
