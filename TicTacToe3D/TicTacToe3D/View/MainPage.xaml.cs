    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace TicTacToe3D
{
    public partial class MainPage : ContentPage
    {

    //    MainViewModel main;
        Button SelectedButton;


        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();

            NewGame();
/*
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += (sender, e) =>
            {
                var viewModel = (MainViewModel)BindingContext;

                if (viewModel.PaintCommand.CanExecute(e))
                {
                    Debug.WriteLine("Attempt to execute PaintCommmand.");
                    viewModel.PaintCommand.Execute(e);
                }
            };
*/
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            Debug.WriteLine("Entered OnCanvasViewPaintSurface.");
} /*
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            SKPaint LargeRing = new SKPaint
            {
                Style = SKPaintStyle.Stroke,

         //       Color = currentPlayerColor.WithAlpha(CanvasRings.LargeVisible),
                StrokeWidth = (float)(info.Width * 0.10)
            };

            SKPaint MediumRing = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
        //           Color = currentPlayerColor.WithAlpha(rings.MediumVisible),
                StrokeWidth = (float)(info.Width * 0.10)
            };

            SKPaint SmallRing = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = RingList[0].SmallColor,
        //        Color = currentPlayerColor.WithAlpha(BaseViewModel.smallVisible),
                StrokeWidth = (float)(info.Width * 0.10)
             };

            float LargeRingSize = (float) (info.Width * 0.80);
            float MediumRingSize = (float)(info.Width * 0.45);
            float SmallRingSize = (float)(info.Width * 0.10);

            canvas.DrawCircle(info.Width / 2, info.Height / 2, LargeRingSize / 2, LargeRing);
            canvas.DrawCircle(info.Width / 2, info.Height / 2, MediumRingSize / 2, MediumRing);
            canvas.DrawCircle(info.Width / 2, info.Height / 2, SmallRingSize / 2, SmallRing);

        }*/

        public void OnTouch(object sender, SKTouchEventArgs e)
        {
        }



        public void NewGame()
        {
        }

        public void OnTouchSelection(object sender, SKTouchEventArgs e)
        {
           // (sender as SKCanvasView).InvalidateSurface();

        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            var o = (sender as Button);
            if (SelectedButton != null)
            {
                SelectedButton.BackgroundColor = Color.Green;
            }
            o.BackgroundColor = Color.Red;
            SelectedButton = o;
        }

    }
}