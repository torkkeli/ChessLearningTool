using ChessLearningTool.Logic.ChessLogic.Pieces;

namespace ChessLearningTool.Logic.Models
{
    public sealed class ChessMove
    {
        public ChessMove(BoardCoordinates start, BoardCoordinates end, IChessPiece piece)
        {
            Start = start;
            End = end;
            Piece = piece;
        }

        public BoardCoordinates Start { get; }

        public BoardCoordinates End { get; }

        public IChessPiece Piece { get; }
    }
}
