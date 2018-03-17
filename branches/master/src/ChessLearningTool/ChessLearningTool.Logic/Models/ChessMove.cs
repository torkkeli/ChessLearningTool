using ChessLearningTool.Logic.ChessLogic.Pieces;

namespace ChessLearningTool.Logic.Models
{
    public sealed class ChessMove
    {
        private readonly BoardCoordinates _start;
        private readonly BoardCoordinates _end;
        private readonly IChessPiece _piece;

        public ChessMove(BoardCoordinates start, BoardCoordinates end, IChessPiece piece)
        {
            _start = start;
            _end = end;
            _piece = piece;
        }

        public BoardCoordinates Start => _start;

        public BoardCoordinates End => _end;

        public IChessPiece Piece => _piece;
    }
}
