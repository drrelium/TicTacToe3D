using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TicTacToe3D
{
    class MainViewModel : BaseViewModel
    {

        public ICommand RingSelectionCommand{ set; get; }
        public ICommand DisplaySelectionCommand { set; get; }
        public ICommand PaintCommand { get; set; }
        public ObservableCollection<CanvasRing> RingList { get; set; }
        public int BoardWidth = 3;
        public SKColor largeColor;
        public int selectedRingSize;
        public SKColor currentPlayerColor;
        public CanvasRing currentCanvasRing;

        private ObservableCollection<CanvasRing> canvasList;

        public ObservableCollection<CanvasRing> CanvasList
        {
            get { return canvasList; }
            set
            {
                if (canvasList != value)
                {
                    canvasList = value;
                    OnPropertyChanged("CanvasList");
                }
            }
        }

    


        public MainViewModel()
        {
            CanvasList = new ObservableCollection<CanvasRing>();
            RingList = new ObservableCollection<CanvasRing>();
            NewList(CanvasList, BoardWidth * BoardWidth);
            NewList(RingList, BoardWidth);

            RingSelectionCommand = new Command<object>(UpdateSelectedRing);
            DisplaySelectionCommand = new Command<object>(UpdateRing);
            PaintCommand = new Command<SKPaintSurfaceEventArgs>(OnPainting);
            currentPlayerColor = Color.Yellow.ToSKColor();
        }

        public void UpdateSelectedRing(object o)
        {
            var item = (o as CanvasRing);
            int selectedRingSize = item.Location;
            //         Debug.WriteLine("Clicked location " + location.ToString());
        }

        public void UpdateRing(object o)
        {
            var currentCanvasRing = (o as CanvasRing);
            int location = currentCanvasRing.Location;
            //         Debug.WriteLine("Clicked location " + location.ToString());
            
            switch (selectedRingSize)
            {
                case 0:
                    currentCanvasRing.SmallColor = currentPlayerColor;
                    return;
                case 1:
                    currentCanvasRing.MediumColor = currentPlayerColor;
                    return;
                case 2:
                    currentCanvasRing.LargeColor = currentPlayerColor;
                    return;
                default:
                    Debug.WriteLine("Error: A ring size needs to be selected");
                    return;
            }
        }


        private void OnPainting(SKPaintSurfaceEventArgs e)
        {
            Debug.WriteLine("LargeColor is " + this.ToString());           
       //     Debug.WriteLine("location= " + location);
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
 //               this.LargeColor = LargeColor;

        


            SKPaint LargeRing = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = LargeColor,
                StrokeWidth = (float)(info.Width * 0.10)
            };

            float LargeRingSize = (float)(info.Width * 0.80);

            canvas.DrawCircle(info.Width / 2, info.Height / 2, LargeRingSize / 2, LargeRing);
        }

        public void NewList(ObservableCollection<CanvasRing> list, int size) 
        {
            for (int x = 0; x < size; x++)
            {
                list.Add(new CanvasRing
                {
                    SmallColor = Color.Transparent.ToSKColor(),
                    MediumColor = Color.Transparent.ToSKColor(),
                    LargeColor = Color.Blue.ToSKColor(),
                    Location = x
                });

            }
        }

#region properties  

        public SKColor LargeColor
        {
                get
                {
                if (currentCanvasRing == null)
                    return Color.Transparent.ToSKColor();
                else
                    return currentCanvasRing.LargeColor;
                }
                set
                {
                    if (currentCanvasRing.LargeColor != value)
                        currentCanvasRing.LargeColor = value;
                    Debug.WriteLine("LargeColor= " + LargeColor);
                    OnPropertyChanged("LargeColor");
                }

        }
        #endregion
    }
}
