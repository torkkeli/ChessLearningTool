using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public interface IChessPiece
    {
        event Action<ChessMove> MoveMade;

        string ImagePath { get; }

        ChessColor Color { get; }

        void TryMakeMove(BoardCoordinates square);
    }
}
