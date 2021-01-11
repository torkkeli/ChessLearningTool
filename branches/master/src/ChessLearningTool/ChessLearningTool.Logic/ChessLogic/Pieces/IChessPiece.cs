using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public interface IChessPiece
    {
        event Action<ChessMove> MoveMade;

        Bitmap Image { get; }

        ChessColor Color { get; }

        decimal Value { get; }

        BoardCoordinates Coordinates { get; set; }

        bool TryMakeMove(BoardCoordinates square, ChessPosition position);

        IEnumerable<BoardCoordinates> LegalMoves(ChessPosition position);

        IChessPiece Copy();
    }
}
