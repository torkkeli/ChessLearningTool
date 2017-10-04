using ChessLearningTool.Data.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Presentation.ViewModels
{
    public sealed class ChessPieceViewModel : ViewModel
    {
        private readonly ChessBoardViewModel _boardViewModel;

        private Point _point;
        private ChessPieceType _pieceType;
        private ChessColor _color;
        public ChessPieceViewModel(
            ChessBoardViewModel boardViewModel,
            Point point,
            ChessPieceType pieceType,
            ChessColor color)
            : base(string.Empty)
        {
            _boardViewModel = boardViewModel;

            _point = point;
            _pieceType = pieceType;
            _color = color;
        }

        public Point Point
        {
            get { return _point; }
            set { Set(ref _point, () => Point, value); }
        }

        public ChessPieceType PieceType
        {
            get { return _pieceType; }
            set { Set(ref _pieceType, () => PieceType, value); }
        }

        public ChessColor Color
        {
            get { return _color; }
            set { Set(ref _color, () => Color, value); }
        }
    }
}
