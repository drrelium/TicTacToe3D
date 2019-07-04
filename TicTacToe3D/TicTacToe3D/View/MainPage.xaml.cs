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
        int currentPlayer;
        MainViewModel main;
        int ringCount;
        SKColor currentColor;


        public MainPage()
        {
            InitializeComponent();
            main = new MainViewModel();
            BindingContext = main;
            currentPlayer = 0;
            ringCount = main.BoardWidth;
            PlayerAmount.SelectedIndexChanged += OnPickerSelectedIndexChanged;
            currentColor = Color.Transparent.ToSKColor();
            FlexBoard.IsEnabled = false;
            MessagesListView.IsEnabled = false;
        }

        public void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            Debug.WriteLine("Entered OnCanvasViewPaintSurface.");

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            int numberOfRings = main.BoardWidth;
            int spaceDivders = 4;
            int strokeWidth = info.Width / (numberOfRings * spaceDivders);
            int ringSize = -1;

            Ring = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = currentColor,
                StrokeWidth = (float)(strokeWidth)
            };

            switch (main.SelectedRingSize)
            {
                case 0:
                    ringSize = 0;
                    break;
                case 1:
                    ringSize = 1;
                    break;
                case 2:
                    ringSize = 2;
                    break;
                default:
                    Debug.WriteLine("Error: A ring size needs to be selected");
                    break;
            }

            float RingRadius = (float)(strokeWidth + (2 * (ringSize * strokeWidth)));
            canvas.DrawCircle(info.Width / 2, info.Height / 2, RingRadius, Ring);
        }

        private void TouchEvent(object sender, SKTouchEventArgs args)
        {
            Debug.WriteLine("Refreshing touch event.");
            currentColor = main.PlayerList[currentPlayer].PlayerColor;
            args.Handled = true;
            ((SKCanvasView)sender).InvalidateSurface();
        }

        public void OnRingCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            Debug.WriteLine("Entered OnCanvasViewPaintSurface.");

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            int numberOfRings = main.BoardWidth;
            int spaceDivders = 4;
            int strokeWidth = info.Width / (numberOfRings * spaceDivders);

            Ring = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Black.ToSKColor(),
                StrokeWidth = (float)(strokeWidth)
            };

            if (ringCount >= main.BoardWidth - 1)
            {
                ringCount = 0;
                //RingCounter.Text = main.PlayerList[currentPlayer].RemainingSmallRings;
            }
            else
            {
                ringCount++;
            }
            
            float RingRadius = (float)(strokeWidth + (2 * (ringCount * strokeWidth)));
            canvas.DrawCircle(info.Width / 2, info.Height / 2, RingRadius, Ring);
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
            FlexBoard.IsEnabled = true;
            Prompt.Text = "Please select a location on the board.";
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            MessagesListView.IsEnabled = true;
            var picker = (Picker)sender;
            int numberOfOpponents = (picker.SelectedIndex) + 1;
            main.CreaterPlayers(numberOfOpponents);
            Debug.WriteLine("numberOfOpponents= " + numberOfOpponents);
            picker.IsVisible = false;
            Prompt.IsVisible = true;
            Prompt.Text = "Please select a ring size.";

        }
    }
}