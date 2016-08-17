using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Game2.Engine
{
    [DebuggerDisplay("{ToString(), nq}")]
    public struct Rank : IEquatable<Rank>, IComparable<Rank>, IComparable
    {
        public static Rank Two { get; } = new Rank(2);

        public static Rank Three { get; } = new Rank(3);

        public static Rank Four { get; } = new Rank(4);

        public static Rank Five { get; } = new Rank(5);

        public static Rank Six { get; } = new Rank(6);

        public static Rank Seven { get; } = new Rank(7);

        public static Rank Eight { get; } = new Rank(8);

        public static Rank Nine { get; } = new Rank(9);

        public static Rank Ten { get; } = new Rank(10);

        public static Rank Jack { get; } = new Rank(11);

        public static Rank Queen { get; } = new Rank(12);

        public static Rank King { get; } = new Rank(13);

        public static Rank Ace { get; } = new Rank(14);

        public static Rank Unkown { get; } = default(Rank);

        public static Rank[] List { get; } = { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

        private Rank(byte value)
        {
            Value = value;
        }

        public byte Value { get; }

        public string Name => GetName(Value);

        public char Symbol => GetSymbol(Value);

        public int CompareTo(Rank other)
        {
            return Value - other.Value;
        }

        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return -1;
            }

            if (obj is Rank)
            {
                return CompareTo((Rank) obj);
            }

            return -1;
        }

        public bool Equals(Rank other)
        {
            return Value == other.Value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && obj is Rank && Equals((Rank) obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(Rank left, Rank right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Rank left, Rank right)
        {
            return !left.Equals(right);
        }

        public static bool operator >(Rank left, Rank right)
        {
            return left.Value > right.Value;
        }

        public static bool operator <(Rank left, Rank right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >=(Rank left, Rank right)
        {
            return left.Value >= right.Value;
        }

        public static bool operator <=(Rank left, Rank right)
        {
            return left.Value <= right.Value;
        }

        public override string ToString()
        {
            return Name;
        }

        private static string GetName(byte value)
        {
            switch (value)
            {
                case 2: return nameof(Two);
                case 3: return nameof(Three);
                case 4: return nameof(Four);
                case 5: return nameof(Five);
                case 6: return nameof(Six);
                case 7: return nameof(Seven);
                case 8: return nameof(Eight);
                case 9: return nameof(Nine);
                case 10: return nameof(Ten);
                case 11: return nameof(Jack);
                case 12: return nameof(Queen);
                case 13: return nameof(King);
                case 14: return nameof(Ace);
                default: return nameof(Unkown);
            }
        }

        private static char GetSymbol(byte value)
        {
            switch (value)
            {
                case 2: return '2';
                case 3: return '3';
                case 4: return '4';
                case 5: return '5';
                case 6: return '6';
                case 7: return '7';
                case 8: return '8';
                case 9: return '9';
                case 10: return 'T';
                case 11: return 'J';
                case 12: return 'Q';
                case 13: return 'K';
                case 14: return 'A';
                default: return '?';
            }
        }
    }
}