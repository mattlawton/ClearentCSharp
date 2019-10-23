using System.Collections.Generic;

namespace Clearent_CsharpProject
{
    public class Wallet {
    
        private readonly List<Card> _cards = new List<Card>();
        public readonly string Name;
    
        public Wallet(string name) {
            Name = name;
        }
    
        public Card GetCardByName(string name) {
            foreach (var c in _cards) {
                if (c.Name.Equals(name)) {
                    return c;
                }
            
            }
            return null;
        }
    
        public void AddCard(Card c) {
            _cards.Add(c);
        }
    
        public IEnumerable<Card> GetCards() {
            return _cards;
        }
    }
}