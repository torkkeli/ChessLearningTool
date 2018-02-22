using System;
using System.IO;
using System.Windows.Data;

using ChessLearningTool.Data.Enums;

namespace ChessLearningTool.Presentation.Converters
{
    [ValueConversion(typeof(ChessPieceType), typeof(string))]
    public sealed class ChessPieceToImageConverter : ValueConverter<ChessPieceType, string>
    {
        protected override string Convert(ChessPieceType value)
        {
            string path = @"E:\Programmering\Repos\CLT\ChessLearningTool\branches\master\src\ChessLearningTool\ChessLearningTool.Presentation\Images";

            switch (value)
            {
                case ChessPieceType.None:
                    return string.Empty;
                case ChessPieceType.WhitePawn:
                    path += @"\White_Pawn.png";
                    break;
                case ChessPieceType.WhiteKnight:
                    path += @"\White_Knight.png";
                    break;
                case ChessPieceType.WhiteBishop:
                    path += @"\White_Bishop.png";
                    break;
                case ChessPieceType.WhiteRook:
                    path += @"\White_Rook.png";
                    break;
                case ChessPieceType.WhiteQueen:
                    path += @"\White_Queen.png";
                    break;
                case ChessPieceType.WhiteKing:
                    path += @"\White_King.png";
                    break;
                case ChessPieceType.BlackPawn:
                    path += @"\Black_Pawn.png";
                    break;
                case ChessPieceType.BlackKnight:
                    path += @"\Black_Knight.png";
                    break;
                case ChessPieceType.BlackBishop:
                    path += @"\Black_Bishop.png";
                    break;
                case ChessPieceType.BlackRook:
                    path += @"\Black_Rook.png";
                    break;
                case ChessPieceType.BlackQueen:
                    path += @"\Black_Queen.png";
                    break;
                case ChessPieceType.BlackKing:
                    path += @"\Black_King.png";
                    break;
                default:
                    throw new Exception(
                $"BUG - ChessPieceToImageConverter.Convert: {value} could not be converted to {typeof(ChessPieceType).Name}");
            }

            return path;
        }

        protected override ChessPieceType ConvertBack(string value)
        {
            throw new NotImplementedException();
        }
    }
}
