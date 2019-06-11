using System;
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

        Button SelectedButton;
        SKPaint Ring;
        SKColor currentColor;
        MainViewModel main;

        public MainPage()
        {
            InitializeComponent();
            main = new MainViewModel();
            BindingContext = main;
            currentColor = Color.Transparent.ToSKColor();

        }

        public void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            Debug.WriteLine("Entered OnCanvasViewPaintSurface.");
         
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            int CanvasIndex = main.ClickedLocation;

            Ring = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = currentColor,
                StrokeWidth = (float)(info.Width * 0.10)
            };

            float LargeRingSize = (float) (info.Width * 0.80);
            float MediumRingSize = (float)(info.Width * 0.45);
            float SmallRingSize = (float)(info.Width * 0.10);


            switch (main.SelectedRingSize)
            {
                case 0:
                    canvas.DrawCircle(info.Width / 2, info.Height / 2, SmallRingSize / 2, Ring);
                    break;
                case 1:
                    canvas.DrawCircle(info.Width / 2, info.Height / 2, MediumRingSize / 2, Ring);
                    break;
                case 2:
                    Debug.WriteLine("Changing LargeColor.");
                    canvas.DrawCircle(info.Width / 2, info.Height / 2, LargeRingSize / 2, Ring);

                    break;
                default:
                    Debug.WriteLine("Error: A ring size needs to be selected");
                    break;
            }
        }

  /*      public SKColor GetRingColor()
        {
            /*         if (Ring.Color == null)
                     {
                         return Color.Blue.ToSKColor();
                     }
                     else
                     {
                         return Ring.Color; 
                     }
            return Color.Blue.ToSKColor();

        }*/
/*
        void OnCanvasViewTapped(object sender, EventArgs args)
        {
            Debug.WriteLine("Refreshing surface. ");
            (sender as SKCanvasView).InvalidateSurface();
            
        }
*/
        private void TouchEvent(object sender, SKTouchEventArgs args)
        {
            Debug.WriteLine("Refreshing touch event.");
            //       Debug.WriteLine("Elements: " + FlexBoard.GetChildElements(args.Location.ToFormsPoint()).ToString());
           currentColor = Color.Blue.ToSKColor();
            args.Handled = true;
            ((SKCanvasView)sender).InvalidateSurface();
        }

        
/*
        private void ButtonClicked(object sender, EventArgs e)
        {
            var o = (sender as Button);
            if (SelectedButton != null)
            {
                SelectedButton.BackgroundColor = Color.Green;
            }
            o.BackgroundColor = Color.Red;
            SelectedButton = o;

            //     RingSelectionCanvas.InvalidateSurface();
        }
        */
    }
}