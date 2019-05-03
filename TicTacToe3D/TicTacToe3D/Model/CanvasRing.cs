using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace TicTacToe3D
{
    class CanvasRing
    {
        public SKColor SmallColor { get; set; }
        public SKColor MediumColor { get; set; }
        public SKColor LargeColor { get; set; }
        public int Location { get; set; }
    }
}
