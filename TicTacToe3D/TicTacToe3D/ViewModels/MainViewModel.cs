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
  //      public ICommand TapCommand { get; set; }

        public ObservableCollection<CanvasRing> RingList { get; set; }
        public ObservableCollection<Player> PlayerList { get; set; }
        public int BoardWidth = 3;
        public SKColor largeColor;
        public int SelectedRingSize;
        public int ClickedLocation;
        public SKColor currentPlayerColor;
        public CanvasRing currentCanvasRing;
        int PlayerCount;


        public ObservableCollection<CanvasRing> CanvasList { get; set; }

        public MainViewModel()
        {
            CanvasList = new ObservableCollection<CanvasRing>();
            RingList = new ObservableCollection<CanvasRing>();

            NewList(CanvasList, BoardWidth * BoardWidth);
            NewList(RingList, BoardWidth);

            RingSelectionCommand = new Command<object>(UpdateSelectedRing);
            DisplaySelectionCommand = new Command<object>(UpdateRing);
     //       PaintCommand = new Command<SKPaintSurfaceEventArgs>(OnPainting);
            currentPlayerColor = Color.Yellow.ToSKColor();
    //        MaximumPlayerCount = 4;

        }

        public void NewRingSize(int size)
        {
            SelectedRingSize = size;
        }

        public void UpdateSelectedRing(object o)
        {
            var item = (o as CanvasRing);
            NewRingSize(item.Location);
            Debug.WriteLine("Clicked selectedRingSize " + SelectedRingSize);
        }

        public void UpdateRing(object o)
        {
            Debug.WriteLine("Entering UpdateRing");

            var currentCanvasRing = (o as CanvasRing);
            int ClickedLocation = currentCanvasRing.Location;

            /*
            switch (SelectedRingSize)
            {
                case 0:
                    currentCanvasRing.SmallColor = currentPlayerColor;
                    break;
                case 1:
                    currentCanvasRing.MediumColor = currentPlayerColor;
                    break;
                case 2:
                   Debug.WriteLine("Changing LargeColor.");
                    CanvasList[ClickedLocation].LargeColor = currentPlayerColor;
                    currentCanvasRing.LargeColor = currentPlayerColor;
                    break;
                default:
                    Debug.WriteLine("Error: A ring size needs to be selected");
                    break;
            }
                    Debug.WriteLine("selectedRingSize= " + SelectedRingSize + ", currentCanvasRing= " + currentCanvasRing.LargeColor.ToString());
      */
        }

/*
        private void OnPainting(SKPaintSurfaceEventArgs e)
        {
            Debug.WriteLine("LargeColor is " + LargeColor.ToString());           
       //     Debug.WriteLine("location= " + location);
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            SKPaint LargeRing = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = LargeColor,
                StrokeWidth = (float)(info.Width * 0.10)
            };

            float LargeRingSize = (float)(info.Width * 0.80);

            canvas.DrawCircle(info.Width / 2, info.Height / 2, LargeRingSize / 2, LargeRing);
        }
        */
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

        public void CreaterPlayers(int count)
        {
            int maximumNumberOfRings = BoardWidth;
            PlayerList = new ObservableCollection<Player>();
          
            for (int x = 0; x < count + 1 ; x++)
            {
                PlayerList.Add(new Player
                {
                    RemainingLargeRings = maximumNumberOfRings,
                    RemainingMediumRings = maximumNumberOfRings,
                    RemainingSmallRings = maximumNumberOfRings,
                    Index = x
                });

                switch (x)
                {
                    case 0:
                        PlayerList[0].Name = "Player One";
                        PlayerList[0].PlayerColor = Color.Blue.ToSKColor();
                        break;
                    case 1:
                        PlayerList[1].Name = "Player Two";
                        PlayerList[1].PlayerColor = Color.Green.ToSKColor();
                        break;
                    case 2:
                        PlayerList[2].Name = "Player Three";
                        PlayerList[2].PlayerColor = Color.Yellow.ToSKColor();
                        break;
                    case 3:
                        PlayerList[3].Name = "Player Four";
                        PlayerList[3].PlayerColor = Color.Brown.ToSKColor();
                        break;
                    default:
                        Debug.WriteLine("Error: Outside of number of players.");
                        break;

                }
            }
        }
    }
}
