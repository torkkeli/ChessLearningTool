using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public abstract class ChessPiece : IChessPiece
    {
        private readonly ChessColor _color;

        private BoardCoordinates _coordinates;

        protected ChessPiece(ChessColor color, BoardCoordinates coordinates)
        {
            _color = color;
            _coordinates = coordinates;
        }

        public event Action<ChessMove> MoveMade;

        public abstract string ImagePath { get; }

        protected string ImageFolder => @"E:\Programmering\Repos\CLT\ChessLearningTool\branches\master\src\ChessLearningTool\ChessLearningTool.Presentation\Images\";

        protected BoardCoordinates Coordinates => _coordinates;

        public ChessColor Color => _color;

        public void TryMakeMove(BoardCoordinates to)
        {
            if (IsMoveLegal(to))
            {
                ChessMove move = new ChessMove(_coordinates, to, this);
                
                MoveMade?.Invoke(move);
                _coordinates = to;
            }
        }

        protected abstract bool IsMoveLegal(BoardCoordinates square);
    }
}
