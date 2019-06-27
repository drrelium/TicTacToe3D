using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace TicTacToe3D
{
    class Player
    {
        public SKColor PlayerColor { get; set; }
        public int RemainingLargeRings { get; set; }
        public int RemainingMediumRings { get; set; }
        public int RemainingSmallRings { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
    }
}