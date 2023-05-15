using System.Xml;

namespace BackToTheCheckout
{
    public class Checkout
    {
        private Rules rules;
        private int totalPrice = 0;
        private int countA = 0;
        private int countB = 0; 
        private int countC = 0;
        private int countD = 0;
        public Checkout(Rules rules)
        {
            this.rules = rules;
            
        }

        public int CalculateTotalPrice(string input)
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
        
        public int Scan(String item)
        {
         
            if (item.Equals("A"))
            {
                countA++;
                
                // Check to see if there are just below the 'special' number of As
                if (countA < rules.SpecialRuleA)
                {
                    totalPrice += rules.CostA;    
                }

                // Check to see if there are more than or equal to the 'special' number of As
                if (countA >= rules.SpecialRuleA)
                {
                    totalPrice = countA * rules.CostA;
                    totalPrice += countB * rules.CostB;
                    totalPrice += countC * rules.CostC;
                    totalPrice += countD * rules.CostD;
                    totalPrice -= (countA / rules.SpecialRuleA) * rules.SpecialSavingsA;
                    totalPrice -= (countB / rules.SpecialRuleB) * rules.SpecialSavingsB;
                }
            }
            
            if (item.Equals("B"))
            {
                countB++;

                // Check to see if there are just below the 'special' number of Bs
                if (countB < rules.SpecialRuleB)
                {
                    totalPrice += rules.CostB;
                }

                if (countB >= rules.SpecialRuleB)
                {
                    totalPrice = countA * rules.CostA;
                    totalPrice += countB * rules.CostB;
                    totalPrice += countC * rules.CostC;
                    totalPrice += countD * rules.CostD;
                    totalPrice -= (countA / rules.SpecialRuleA) * rules.SpecialSavingsA;
                    totalPrice -= (countB / rules.SpecialRuleB) * rules.SpecialSavingsB;
                }
            }
            
            if (item.Equals("C"))
            {
                countC++;
                totalPrice += rules.CostC;
            }

            if (item.Equals("D"))
            {
                countD++;
                totalPrice += rules.CostD;
            }

            

            Console.WriteLine(totalPrice);
            return totalPrice;
        }
    }    
}
