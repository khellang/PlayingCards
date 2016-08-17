using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game2.Engine
{
    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy(typeof(DebuggerView))]
    public sealed class Deck : IReadOnlyCollection<Card>
    {
        private static Card[] CardSource { get; } = GenerateCards(Suit.List, Rank.List);

        public Deck() : this(new Random())
        {
        }

        public Deck(Random random)
        {
            Cards = new Stack<Card>(Shuffle(CardSource, random));
        }

        public int Count => Cards.Count;

        private Stack<Card> Cards { get; }

        private object Gate { get; } = new object();

        public Card Draw()
        {
            lock (Gate)
            {
                EnsureEnoughCards(count: 1);

                return Cards.Pop();
            }
        }

        public Card[] Draw(int count)
        {
            lock (Gate)
            {
                EnsureEnoughCards(count);

                var cards = new Card[count];

                for (var i = 0; i < count; i++)
                {
                    cards[i] = Cards.Pop();
                }

                return cards;
            }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return Cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void EnsureEnoughCards(int count)
        {
            if (Count < count)
            {
                throw new InvalidOperationException("There's not enough cards in the deck.");
            }
        }

        private static Card[] GenerateCards(Suit[] suits, Rank[] ranks)
        {
            var cards = new Card[suits.Length * ranks.Length];

            var index = 0;

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards[index++] = new Card(suit, rank);
                }
            }

            return cards;
        }

        private static IEnumerable<Card> Shuffle(IEnumerable<Card> source, Random random)
        {
            var elements = new List<Card>(source);

            for (var i = elements.Count - 1; i >= 0; i--)
            {
                var swapIndex = random.Next(i + 1);

                yield return elements[swapIndex];

                elements[swapIndex] = elements[i];
            }
        }

        private class DebuggerView
        {
            public DebuggerView(Deck deck)
            {
                Deck = deck;
            }

            private Deck Deck { get; }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public Card[] Cards => Deck.Cards.ToArray();
        }
    }
}