using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace TicTacToe3D
{
    class RingSelection
    {
        public SKColor PlayerColor { get; set; }
        public int RemainingRings { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
    }
}