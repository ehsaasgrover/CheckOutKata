using System.Xml;

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

        public int NewImplementation(string input)
        {
            int costA = 50;
            int costB = 30;
            int costC = 20;
            int countA = 0;
            int countB = 0;
            int countC = 0;
            int specialRuleA = 3;
            int specialSavingsA = 20;
            int specialRuleB = 2;
            int specialSavingsB = 15;
            
            char[] charArray = input.ToCharArray();
            
            Console.WriteLine(charArray);

            foreach (char i in charArray)
            {
                if (i == 'A')
                {
                    countA++;
                }

                if (i == 'B')
                {
                    countB++;
                }

                if (i == 'C')
                {
                    countC++;
                }
            }
            
            int totalPrice = countA * costA;
            totalPrice += countB * costB;
            totalPrice -= (countA / specialRuleA) * specialSavingsA;
            totalPrice += countC * costC;
            totalPrice -= (countB / specialRuleB) * specialSavingsB;
            Console.WriteLine(totalPrice);
            return totalPrice;
            

            Console.WriteLine("A: "+countA+" , B: "+countB+" , C: "+countC);
            
            
        }
    }    
}
