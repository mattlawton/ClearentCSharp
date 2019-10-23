using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Clearent_CsharpProject.test
{
    public class TestInterestRateCalculation {
    
    //  "    1 person has 1 wallet and 3 cards (1 Visa, 1 MC 1 Discover) 
    //  Each Card has a balance of $100 
    //  calculate the total interest (simple interest) for this person and per card.
    [Test]
    public void Test_1_Wallet_3_Cards() {
        var person = new Person();
        person.AddWallet("Wallet 1");
        person.GetWalletByName("Wallet 1").AddCard(new Visa("visa 1"));
        person.GetWalletByName("Wallet 1").AddCard(new Mastercard("mastercard 1"));
        person.GetWalletByName("Wallet 1").AddCard(new Discover("discover 1"));
        person.GetWalletByName("Wallet 1").GetCardByName("visa 1").AdjustBalance(100);
        person.GetWalletByName("Wallet 1").GetCardByName("mastercard 1").AdjustBalance(100);
        person.GetWalletByName("Wallet 1").GetCardByName("discover 1").AdjustBalance(100);
        
        var expected = new List<double> { 10, 5, 1};
        // List of values match
        Assert.True(!expected.Except(InterestFunctions.GetInterest(person)).Any());
        // Same number of values
        Assert.True((expected.Count == InterestFunctions.GetWalletInterest(person, "Wallet 1").Count()));
        // Total is correct
        Assert.AreEqual(16, InterestFunctions.GetTotalInterest(person));
    }
    
    //  "    1 person has 2 wallets  Wallet 1 has a Visa and Discover , wallet 2 a MC -
    //  each card has $100 balance - calculate the total interest(simple interest) for this person and interest per wallet
    [Test]
    public void Test_2_Wallets_3_Cards() {
        var person = new Person();
        person.AddWallet("Wallet 1");
        person.GetWalletByName("Wallet 1").AddCard(new Visa("visa 1"));
        person.GetWalletByName("Wallet 1").AddCard(new Discover("discover 1"));
        person.GetWalletByName("Wallet 1").GetCardByName("visa 1").AdjustBalance(100);
        person.GetWalletByName("Wallet 1").GetCardByName("discover 1").AdjustBalance(100);
        person.AddWallet("Wallet 2");
        person.GetWalletByName("Wallet 2").AddCard(new Mastercard("mastercard 1"));
        person.GetWalletByName("Wallet 2").GetCardByName("mastercard 1").AdjustBalance(100);
        
        // Total is correct
        Assert.AreEqual(16, InterestFunctions.GetTotalInterest(person));
        // Total for each wallet is correct
        Assert.AreEqual(11, InterestFunctions.GetWalletTotalInterest(person, "Wallet 1"));
        Assert.AreEqual(5, InterestFunctions.GetWalletTotalInterest(person, "Wallet 2"));
        
        // Wallet 1
        var expected = new List<double> { 10, 1};
        // Values are correct
        Assert.True(!expected.Except(InterestFunctions.GetWalletInterest(person, "Wallet 1")).Any());
        // Same number of values
        Assert.True((expected.Count == InterestFunctions.GetWalletInterest(person, "Wallet 1").Count()));
        
        // Wallet 2
        var expected2 = new List<double> { 5};
        // Values are correct
        Assert.True(!expected2.Except(InterestFunctions.GetWalletInterest(person, "Wallet 2")).Any());
        // Same number of values
        Assert.True(expected2.Count == InterestFunctions.GetWalletInterest(person, "Wallet 2").Count);
    }
    
    //  "    2 people have 1 wallet each,  person 1 has 1 wallet , with 2 cards MC and visa person 2 has 1 wallet 
    //  1 visa and 1 MC -
    //  each card has $100 balance - calculate the total interest(simple interest) for each person and interest per wallet
    [Test]
    public void Test_2_People_1_Wallet_4_Cards() {
        var first = new Person();
        var second = new Person();
        first.AddWallet("Wallet 1");
        second.AddWallet("Wallet 1");
        first.GetWalletByName("Wallet 1").AddCard(new Mastercard("mastercard 1"));
        first.GetWalletByName("Wallet 1").AddCard(new Mastercard("mastercard 2"));
        second.GetWalletByName("Wallet 1").AddCard(new Visa("visa 1"));
        second.GetWalletByName("Wallet 1").AddCard(new Mastercard("mastercard 1"));
        first.GetWalletByName("Wallet 1").GetCardByName("mastercard 1").AdjustBalance(100);
        first.GetWalletByName("Wallet 1").GetCardByName("mastercard 2").AdjustBalance(100);
        second.GetWalletByName("Wallet 1").GetCardByName("visa 1").AdjustBalance(100);
        second.GetWalletByName("Wallet 1").GetCardByName("mastercard 1").AdjustBalance(100);
        
        Assert.AreEqual(10, InterestFunctions.GetTotalInterest(first));
        Assert.AreEqual(15, InterestFunctions.GetTotalInterest(second));
        Assert.AreEqual(10, InterestFunctions.GetWalletTotalInterest(first, "Wallet 1"));
        Assert.AreEqual(15, InterestFunctions.GetWalletTotalInterest(second, "Wallet 1"));
        
        var expected = new List<double> { 5, 5};
        Assert.True(!expected.Except(InterestFunctions.GetInterest(first)).Any());
        Assert.True((expected.Count == InterestFunctions.GetInterest(first).Count));
        
        var expected2 = new List<double> { 10, 5};
        Assert.True(!expected2.Except(InterestFunctions.GetInterest(second)).Any());
        Assert.True((expected2.Count == InterestFunctions.GetInterest(second).Count));
    }
}
}