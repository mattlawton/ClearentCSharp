using System.Collections.Generic;

namespace Clearent_CsharpProject
{
    public class Person
    {
        private readonly List<Wallet> _wallets = new List<Wallet>();

        public void AddWallet(string name) {
            _wallets.Add(new Wallet(name));
        }

        public Wallet GetWalletByName(string name) {
            foreach (var w in _wallets) {
                if (w.Name.Equals(name)) return w;
            }
            return null;
        }

        public IEnumerable<Wallet> GetWallets() {
            return _wallets;
        }
    }
}