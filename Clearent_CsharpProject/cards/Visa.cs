namespace Clearent_CsharpProject
{
    public class Visa : Card {

        public Visa(string name) {
            InterestRate = CardInterestRates.Visa;
            Name = name;
        }
    }
}