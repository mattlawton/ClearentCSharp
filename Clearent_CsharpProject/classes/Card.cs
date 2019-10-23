namespace Clearent_CsharpProject
{
    public class Card
    {
        public double Balance;
        public double InterestRate;
        public string Name;

        protected Card()
        {
        }

        public void AdjustBalance(double amount)
        {
            Balance += amount;
        }
    }
}