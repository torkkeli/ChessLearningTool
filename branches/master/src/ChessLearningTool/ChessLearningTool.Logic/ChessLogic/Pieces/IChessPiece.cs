using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public interface IChessPiece
    {
        event Action<ChessMove> MoveMade;

        Bitmap Image { get; }

        ChessColor Color { get; }

        void TryMakeMove(BoardCoordinates square, ChessPosition position);
    }
}
