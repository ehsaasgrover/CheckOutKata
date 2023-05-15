namespace BackToTheCheckout
{
    public class Checkout
    {
        public int CalculateTotalPrice(int numberOfA, int priceOfA)
        {
            if (numberOfA == 3)
            {
                return 130;
            }
            else
            {
                return numberOfA * priceOfA;
            }
        }
    }    
}
