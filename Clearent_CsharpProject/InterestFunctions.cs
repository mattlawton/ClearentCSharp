using System;
using System.Collections.Generic;
using System.Linq;

namespace Clearent_CsharpProject
{
    public static class InterestFunctions {
    
        public static List<double> GetInterest(Person person) {
            var interests = new List<double>();
            foreach (var w in person.GetWallets())
            {
                interests.AddRange(w.GetCards()
                    .Select(c => (c.InterestRate * c.Balance)));
            }
        
            return interests;
        }
    
        public static List<double> GetWalletInterest(Person person, string name)
        {
            return person.GetWalletByName(name)
                .GetCards()
                .Select(c => (c.InterestRate * c.Balance))
                .ToList();
        }
    
        public static double GetWalletTotalInterest(Person person, string name)
        {
            return person.GetWalletByName(name)
                .GetCards()
                .Aggregate<Card, double>(0, (current, c) => (current + (c.InterestRate * c.Balance)));
        }
    
        public static double GetTotalInterest(Person person)
        {
            return person.GetWallets()
                .SelectMany(w => w.GetCards())
                .Sum(c => (c.InterestRate * c.Balance));
        }
    }
}