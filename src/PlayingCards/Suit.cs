using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Game2.Engine
{
    [DebuggerDisplay("{ToString(), nq}")]
    public struct Suit : IEquatable<Suit>, IComparable<Suit>, IComparable
    {
        public static Suit Spades { get; } = new Suit('♠');

        public static Suit Hearts { get; } = new Suit('♥');

        public static Suit Clubs { get; } = new Suit('♣');

        public static Suit Diamonds { get; } = new Suit('♦');

        public static Suit Unknown { get; } = default(Suit);

        public static Suit[] List { get; } = { Spades, Hearts, Clubs, Diamonds };

        private Suit(char symbol)
        {
            Symbol = symbol;
        }

        public char Symbol { get; }

        public string Name => GetName(Symbol);

        public int CompareTo(Suit other)
        {
            return Symbol - other.Symbol;
        }

        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return -1;
            }

            if (obj is Suit)
            {
                return CompareTo((Suit) obj);
            }

            return -1;
        }

        public bool Equals(Suit other)
        {
            return Symbol == other.Symbol;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && obj is Suit && Equals((Suit) obj);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }

        public static bool operator ==(Suit left, Suit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Suit left, Suit right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return Name;
        }

        private static string GetName(char symbol)
        {
            switch (symbol)
            {
                case '♠': return nameof(Spades);
                case '♥': return nameof(Hearts);
                case '♦': return nameof(Diamonds);
                case '♣': return nameof(Clubs);
                default: return nameof(Unknown);
            }
        }
    }
}