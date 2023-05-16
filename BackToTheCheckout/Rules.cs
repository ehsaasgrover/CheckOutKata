using System.Runtime.CompilerServices;
using System.Xml.Xsl;

namespace BackToTheCheckout;

// Rules Class that defines all the costs, special rules and special discount
public class Rules
{
    public int CostA { get; set; }
    public int CostB { get; set; }
    public int CostC { get; set; }
    public int CostD { get; set; }
    public int SpecialRuleA { get; set; }
    public int SpecialSavingsA { get; set; }
    public int SpecialRuleB { get; set; }
    public int SpecialSavingsB { get; set; }
    
    // Rules constructor
    public Rules(int costA, int costB, int costC, int costD, int specialRuleA,
        int specialSavingsA, int specialRuleB, int specialSavingsB)
    {
        CostA = costA;
        CostB = costB;
        CostC = costC;
        CostD = costD;
        SpecialRuleA = specialRuleA;
        SpecialSavingsA = specialSavingsA;
        SpecialRuleB = specialRuleB;
        SpecialSavingsB = specialSavingsB;
    }
}