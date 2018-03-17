using System;

namespace ChessLearningTool.Logic.Models
{
    public sealed class BoardCoordinates : IEquatable<BoardCoordinates>
    {
        private readonly int _row;
        private readonly int _column;

        public BoardCoordinates(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public int Row => _row;

        public int Column => _column;

        public bool Equals(BoardCoordinates other)
        {
            return other.Row == Row && other.Column == Column;
        }

        public override int GetHashCode()
        {
            return Row + (Column * 10);
        }
    }
}
