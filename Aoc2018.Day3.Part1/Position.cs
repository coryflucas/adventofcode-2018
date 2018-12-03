namespace Aoc2018.Day3.Part1
{
    public class Position
    {
        public int Left { get; set; }
        public int Top { get; set; }

        private bool Equals(Position other)
        {
            return Left == other.Left && Top == other.Top;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Left * 397) ^ Top;
            }
        }
    }
}