using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using ChessLearningTool.Data.Enums;

namespace ChessLearningTool.Presentation.Converters
{
    public sealed class ChessPieceToImageConverter : ValueConverter<ChessPieceType, string>
    {
        protected override string Convert(ChessPieceType value)
        {
            switch (value)
            {
                case ChessPieceType.WhitePawn:
                    return "WhitePawn.jpg";
                case ChessPieceType.WhiteKnight:
                    return "WhiteKnight.jpg";
                case ChessPieceType.WhiteBishop:
                    return "WhiteBishop.jpg";
                case ChessPieceType.WhiteRook:
                    return "WhiteRook.jpg";
                case ChessPieceType.WhiteQueen:
                    return "WhiteQueen.jpg";
                case ChessPieceType.WhiteKing:
                    return "WhiteKing.jpg";
                case ChessPieceType.BlackPawn:
                    return "BlackPawn.jpg";
                case ChessPieceType.BlackKnight:
                    return "BlackKnight.jpg";
                case ChessPieceType.BlackBishop:
                    return "BlackBishop.jpg";
                case ChessPieceType.BlackRook:
                    return "BlackRook.jpg";
                case ChessPieceType.BlackQueen:
                    return "BlackQueen.jpg";
                case ChessPieceType.BlackKing:
                    return "BlackKing.jpg";
            }

            throw new Exception(
                string.Format(
                    "BUG - ChessPieceToImageConverter.Convert: {0} could not be converted to {1}",
                    value,
                    typeof(ChessPieceType).Name));
        }

        protected override ChessPieceType ConvertBack(string value)
        {
            throw new NotImplementedException();
        }
    }
}
