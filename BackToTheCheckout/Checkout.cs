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

        public int NewImplementation(string input, Rules rules)
        {
            int countA = 0;
            int countB = 0;
            int countC = 0;
            int countD = 0;
                        
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

                if (i == 'D')
                {
                    countD++;
                }
            }
            
            int totalPrice = countA * rules.CostA;
            totalPrice += countB * rules.CostB;
            totalPrice += countC * rules.CostC;
            totalPrice += countD * rules.CostD;
            totalPrice -= (countA / rules.SpecialRuleA) * rules.SpecialSavingsA;
            totalPrice -= (countB / rules.SpecialRuleB) * rules.SpecialSavingsB;
            
            Console.WriteLine(totalPrice);
            Console.WriteLine("A: "+countA+" , B: "+countB+" , C: "+countC+", D: "+countD);
            return totalPrice;
            
        }
    }    
}
