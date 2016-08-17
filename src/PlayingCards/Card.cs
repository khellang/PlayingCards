using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Game2.Engine
{
    [DebuggerDisplay("{ToString(), nq}")]
    public struct Card : IEquatable<Card>, IComparable<Card>, IComparable
    {
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public Suit Suit { get; }

        public Rank Rank { get; }

        public int CompareTo(Card other)
        {
            return Suit.Equals(other.Suit)
                ? Rank.CompareTo(other.Rank)
                : Suit.CompareTo(other.Suit);
        }

        int IComparable.CompareTo(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return -1;
            }

            if (other is Card)
            {
                return CompareTo((Card) other);
            }

            return -1;
        }

        public bool Equals(Card other)
        {
            return Suit.Equals(other.Suit) && Rank.Equals(other.Rank);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            return !ReferenceEquals(null, other) && other is Card && Equals((Card) other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Suit.GetHashCode() * 397) ^ Rank.GetHashCode();
            }
        }

        public static bool operator ==(Card left, Card right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}