// See https://aka.ms/new-console-template for more information

using System;
using System.ComponentModel.Design;

namespace BackToTheCheckout
{
    class Program
    {
        static void Main(string[] args)
        {
            Rules rules = new Rules(50, 30, 20, 15,3, 20, 2, 15);
            Checkout checkout = new Checkout(rules);
            checkout.CalculateTotalPrice("AAA");
            checkout.CalculateTotalPrice("DABABA");
            checkout.CalculateTotalPrice("AAABBCDC");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");
            checkout.Scan("C");

            // playing around with changing rules, debug this its wrong
            Rules rules2 = new Rules(40, 20, 20, 15, 2, 15, 3, 20);
            Checkout checkout2 = new Checkout(rules2);
            checkout.CalculateTotalPrice("AAA");
        }
    }
}