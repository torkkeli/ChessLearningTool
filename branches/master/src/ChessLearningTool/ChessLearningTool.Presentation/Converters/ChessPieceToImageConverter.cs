using System;
using System.IO;
using System.Windows.Data;

using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.ChessLogic.Pieces;

namespace ChessLearningTool.Presentation.Converters
{
    [ValueConversion(typeof(ChessPiece), typeof(string))]
    public sealed class ChessPieceToImageConverter : ValueConverter<ChessPiece, string>
    {
        protected override string Convert(ChessPiece value)
        {
            return value.ImagePath;
        }

        protected override ChessPiece ConvertBack(string value)
        {
            throw new NotImplementedException();
        }
    }
}
