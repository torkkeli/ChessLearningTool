using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public abstract class ChessPiece : IChessPiece
    {
        protected ChessPiece(ChessColor color, BoardCoordinates coordinates)
        {
            Color = color;
            Coordinates = coordinates;
        }

        public event Action<ChessMove> MoveMade;

        public abstract Bitmap Image { get; }

        protected BoardCoordinates Coordinates { get; private set; }

        public ChessColor Color { get; }

        public void TryMakeMove(BoardCoordinates to)
        {
            if (IsMoveLegal(to))
            {
                ChessMove move = new ChessMove(Coordinates, to, this);
                
                MoveMade?.Invoke(move);
                Coordinates = to;
            }
        }

        protected abstract bool IsMoveLegal(BoardCoordinates square);
    }
}
