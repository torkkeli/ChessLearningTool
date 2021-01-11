using ChessLearningTool.Logic.ChessLogic.Pieces;

namespace ChessLearningTool.Logic.Models
{
    public sealed class ChessMove
    {
        public ChessMove(BoardCoordinates start, BoardCoordinates end, IChessPiece piece, bool castle = false)
        {
            Start = start;
            End = end;
            Piece = piece;
            Castle = castle;
        }

        public BoardCoordinates Start { get; }

        public BoardCoordinates End { get; }

        public IChessPiece Piece { get; }

        public bool Castle { get; set; }
    }
}
