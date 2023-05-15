namespace BackToTheCheckout
{
    public class Checkout
    {
        public int CalculateTotalPrice(int numberOfA, int priceOfA, int discountRuleForA, int discountValueForA)
        {
            int totalPrice = numberOfA * priceOfA;
                totalPrice -= (numberOfA / discountRuleForA) * discountValueForA;
            return totalPrice;
        }

        public int CalculateTotalPrice(int numberOfA, int priceOfA, int discountRuleForA, int discountValueForA,
            int numberOfB, int priceOfB, int discountRuleForB, int discountValueForB)
        {
            int totalPrice = numberOfA * priceOfA;
                totalPrice += numberOfB * priceOfB;
                totalPrice -= (numberOfA / discountRuleForA) * discountValueForA;
                totalPrice -= (numberOfB / discountRuleForB) * discountValueForB;
            return totalPrice;
        }

        public int CalculateTotalPrice(int numberOfA, int priceOfA, int discountRuleForA, int discountValueForA,
            int numberOfB, int priceOfB, int discountRuleForB, int discountValueForB, int numberOfC, int priceOfC)
        {
            int totalPrice = numberOfA * priceOfA;
            totalPrice += numberOfB * priceOfB;
            totalPrice += numberOfC * priceOfC;
            totalPrice -= (numberOfA / discountRuleForA) * discountValueForA;
            totalPrice -= (numberOfB / discountRuleForB) * discountValueForB;
            return totalPrice;
        }
    }    
}
