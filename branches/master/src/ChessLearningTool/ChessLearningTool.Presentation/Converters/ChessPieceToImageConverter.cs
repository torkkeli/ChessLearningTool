using System;
using System.Drawing;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using ChessLearningTool.Logic.ChessLogic.Pieces;

namespace ChessLearningTool.Presentation.Converters
{
    [ValueConversion(typeof(ChessPiece), typeof(string))]
    public sealed class ChessPieceToImageConverter : ValueConverter<ChessPiece, BitmapImage>
    {
        protected override BitmapImage Convert(ChessPiece value)
        {
            using (var memory = new System.IO.MemoryStream())
            {
                value.Image.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        protected override ChessPiece ConvertBack(BitmapImage value)
        {
            throw new NotImplementedException();
        }
    }
}
