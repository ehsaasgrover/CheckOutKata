using System.Xml;

namespace BackToTheCheckout
{
    // Checkout Class - Implementation of the methods to calculate the total price
    // and to calculate the incremental total price
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
        
        // Validating input
        private bool isValidInput(string input) 
        { 
            foreach (char c in input)
            { 
                if (c != 'A' && c != 'B' && c != 'C' && c != 'D')
                {
                    return false;
                }
            }
            return true;
        }
        
        // Calculates the total price 
        public int CalculateTotalPrice(string input)
        {
            if (!isValidInput(input))
            {
                throw new ArgumentException("Invalid input. Only items A, B, C or D");
            }
            
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

        
        // Calculates the incremental total price after each scan
        public int Scan(String item)
        {

            if (!isValidInput(item))
            {
                throw new ArgumentException("Invalid input. Only items A, B, C or D");
            }
            
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

                // Check to see if there are more than or equal to the 'special' number of Bs
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
