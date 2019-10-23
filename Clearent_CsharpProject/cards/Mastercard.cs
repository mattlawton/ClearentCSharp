namespace Clearent_CsharpProject
{
    public class Mastercard : Card {

        public Mastercard(string name) {
            InterestRate = CardInterestRates.Mastercard;
            Name = name;
        }
    }
}