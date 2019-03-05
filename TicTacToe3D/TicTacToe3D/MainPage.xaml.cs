using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Collections.ObjectModel;

namespace TicTacToe3D
{
    public partial class MainPage : ContentPage
    {

        ObservableCollection<Ring> Rings;
        float LargeRingSize;
        float MediumRingSize;
        float SmallRingSize;

        public MainPage()
        {
            InitializeComponent();
            NewGame();

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
      //      Board.Children.Add(canvasView, 1, 1);
        }   

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            SKPaint Ring = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Blue.ToSKColor(),
                StrokeWidth = (float)(info.Width * 0.10)
            };

            SKPaint SmallRing = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = Color.Blue.ToSKColor(),
                StrokeWidth = (float)(info.Width * 0.10)
             };

            float LargeRingSize = (float) (info.Width * 0.80);
            float MediumRingSize = (float)(info.Width * 0.45);
            float SmallRingSize = (float)(info.Width * 0.10);

            canvas.DrawCircle(info.Width / 2, info.Height / 2, LargeRingSize / 2, Ring);
            canvas.DrawCircle(info.Width / 2, info.Height / 2, MediumRingSize / 2, Ring);
            canvas.DrawCircle(info.Width / 2, info.Height / 2, SmallRingSize / 2, SmallRing);

        }

        public void NewGame()
        {
            Rings = new ObservableCollection<Ring>();
            int NumberOfColumns = 9;

            for (int x = 0; x < NumberOfColumns; x++)
            {
                Rings.Add(new Ring
                {
                    
                });
            }
        
        }

    }

    public class Ring
    {
        public float Size { get; set; }
        public SKColor Color { get; set; }
        public Boolean Visible { get; set; }
    }

}