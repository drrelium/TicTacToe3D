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
        public ICommand PaintCommand { get; set; }
        public ObservableCollection<CanvasRing> RingList { get; set; }
        public ObservableCollection<CanvasRing> CanvasList { get; set; }
        public int BoardWidth = 3;

        public MainViewModel()
        {
            CanvasList = new ObservableCollection<CanvasRing>();
            RingList = new ObservableCollection<CanvasRing>();
            NewList(CanvasList, BoardWidth * BoardWidth);
            NewList(RingList, BoardWidth);

            RingSelectionCommand = new Command<object>(UpdateRing);
            PaintCommand = new Command<SKPaintSurfaceEventArgs>(OnPainting);
        }

        public void UpdateRing(object o)
        {
            var item = (o as CanvasRing);
            int location = item.Location;
            //         Debug.WriteLine("Clicked location " + location.ToString());
        }

        private void OnPainting(SKPaintSurfaceEventArgs e)
        {
            Debug.WriteLine("Entered OnPainting in MV");
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            SKPaint LargeRing = new SKPaint
            {
                Style = SKPaintStyle.Stroke,

                //       Color = currentPlayerColor.WithAlpha(CanvasRings.LargeVisible),
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
                    LargeColor = Color.Transparent.ToSKColor(),
                    Location = x
                });

            }
        }

#region properties  
public byte SmallVisible
        {
            get { return smallVisible; }
            set
            {
                smallVisible = value;
                OnPropertyChanged("SmallVisible");
            }
        }

        public SKColor SmallColor
        {
            get { return smallColor; }
            set
            {
                smallColor = Color.Yellow.ToSKColor();
                OnPropertyChanged("SmallColor");
            }
        }
        #endregion
    }
}
