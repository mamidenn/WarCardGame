using System;
using System.Collections.Generic;

namespace WarCardGame
{
    internal class Player
    {
        private readonly Queue<IComparable> _hand;

        public bool HasCards => _hand.Count > 0;
        public int CardCount => _hand.Count;

        public Player(IEnumerable<IComparable> cards)
        {
            _hand = new Queue<IComparable>(cards);
        }

        public IComparable PlayCard()
        {
            if (!HasCards)
            {
                throw new OutOfCardsException();
            }
            return _hand.Dequeue();
        }

        public void TakeCard(IComparable card)
        {
            TakeCards(new[] {card});
        }

        public void TakeCards(IComparable[] cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));
            foreach (var card in cards)
            {
                _hand.Enqueue(card);
            }
        }

        public bool CanPlay(int numCards)
        {
            return _hand.Count >= numCards;
        }
    }
}