using System.Diagnostics.CodeAnalysis;

namespace Chessnovert.Shared.Chess
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Coordinate(int row, int col)
        {
            if(row is (< 0 or > 7) || col is (< 0 or > 7) )
                throw new ArgumentException("Coordinate must be in range [0, 7] inclusive");

            this.Row = row;
            this.Col = col;
        }
        public Coordinate()
        {

        }

        public bool Equals(Coordinate other) => this.Row == other.Row && this.Col == other.Col;

        public override bool Equals([NotNullWhen(true)] object? obj) => obj is Coordinate other && this.Equals(other);

        public override int GetHashCode() => (Row,Col).GetHashCode();

        public static bool operator ==(Coordinate left, Coordinate right) => left.Equals(right);

        public static bool operator !=(Coordinate left, Coordinate right) => !left.Equals(right);

        public override string ToString()
        {
            string columnLabels = "ABCDEFGH";
            string algebraicNotation = columnLabels[Col] + Row.ToString();
            return algebraicNotation;
        }

    }
}
