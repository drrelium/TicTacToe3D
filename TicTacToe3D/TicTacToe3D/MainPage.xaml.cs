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


namespace TicTacToe3D
{
    public partial class MainPage : ContentPage
    {

        ObservableCollection<CanvasRings> CanvasList;
        ObservableCollection<CanvasRings> RingList;

        float LargeRingSize;
        float MediumRingSize;
        float SmallRingSize;

        SKColor currentPlayerColor;

        public MainPage()
        {
            InitializeComponent();

            SKColor PlayerOneColor = Color.Blue.ToSKColor();
            currentPlayerColor = PlayerOneColor;

            NewGame();
            RingSelection();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
      //          Grid mainBoard = (Grid)s;
                var item = Grid.GetRow((Grid)s);
                Debug.WriteLine("Entered Tap Action.");
                Debug.WriteLine("Row is: " + item);


            };
     //       Board.GestureRecognizers.Add(tapGestureRecognizer);    

     //       SKCanvasView canvasView = new SKCanvasView();
     //       canvasView.PaintSurface += OnCanvasViewPaintSurface;

   //         Board.Children.Add(canvasView, 0, 1);
     //       canvasView.GestureRecognizers.Add(tapGestureRecognizer);
        }   

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {

            Debug.WriteLine("Entered OnCanvasViewPaintSurface.");
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            

            SKPaint LargeRing = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = currentPlayerColor,
                StrokeWidth = (float)(info.Width * 0.10)
            };

            SKPaint MediumRing = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = currentPlayerColor,
                StrokeWidth = (float)(info.Width * 0.10)
            };

            SKPaint SmallRing = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = currentPlayerColor,
                StrokeWidth = (float)(info.Width * 0.10)
             };

            float LargeRingSize = (float) (info.Width * 0.80);
            float MediumRingSize = (float)(info.Width * 0.45);
            float SmallRingSize = (float)(info.Width * 0.10);

            canvas.DrawCircle(info.Width / 2, info.Height / 2, LargeRingSize / 2, LargeRing);
            canvas.DrawCircle(info.Width / 2, info.Height / 2, MediumRingSize / 2, MediumRing);
            canvas.DrawCircle(info.Width / 2, info.Height / 2, SmallRingSize / 2, SmallRing);
            
        }
        /*
                void OnCanvasViewTapped(object sender, EventArgs args)
                {
                    Debug.WriteLine("Entered OnCanvasViewTapped.");

                    (sender as SKCanvasView).InvalidateSurface();
                }
*/
        void OnTouch(object sender, SKTouchEventArgs e)
        {
            Debug.WriteLine("Entered OnTouch.");

        }

        public void NewGame()
        {
            CanvasList = new ObservableCollection<CanvasRings>();
            int NumberOfCanvases = 9;

            for (int x = 0; x < NumberOfCanvases; x++)
            {
                CanvasList.Add(new CanvasRings
                {
                    SmallVisible = 0,
                    SmallColor = currentPlayerColor,
                    MediumVisible = 0,
                    MediumColor = currentPlayerColor,
                    LargeVisible = 0,
                    LargeColor = currentPlayerColor,
                });
            }
            BindableLayout.SetItemsSource(flexBoard, CanvasList);
        }

        public void RingSelection()
        {
            SKCanvasView canvasView = new SKCanvasView();
            RingList = new ObservableCollection<CanvasRings>();

            RingList.Add(new CanvasRings
            {
                SmallVisible = 0,
                SmallColor = currentPlayerColor,
                MediumVisible = 0,
                MediumColor = currentPlayerColor,
                LargeVisible = 0,
                LargeColor = currentPlayerColor,
            });

            RingList.Add(new CanvasRings
            {
                SmallVisible = 0,
                SmallColor = currentPlayerColor,
                MediumVisible = 0,
                MediumColor = currentPlayerColor,
                LargeVisible = 0,
                LargeColor = currentPlayerColor,
            });

            RingList.Add(new CanvasRings
            {
                SmallVisible = 0,
                SmallColor = currentPlayerColor,
                MediumVisible = 0,
                MediumColor = currentPlayerColor,
                LargeVisible = 0,
                LargeColor = currentPlayerColor,
            });

            BindableLayout.SetItemsSource(MessagesListView, RingList);


            SKPaint LargeRing = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Black.ToSKColor(),
                StrokeWidth = (float)(canvasView.Width * 0.10)
            };

        }

    }

    // For Visiblity an Alpha value of 0 is fully transparnt, and an alpha value of 0xFF is fully opaque.  
    public class CanvasRings
    {
        public int SmallVisible { get; set; }
        public SKColor SmallColor { get; set; }
        public int MediumVisible { get; set; }
        public SKColor MediumColor { get; set; }
        public int LargeVisible { get; set; }
        public SKColor LargeColor { get; set; }
    }

}