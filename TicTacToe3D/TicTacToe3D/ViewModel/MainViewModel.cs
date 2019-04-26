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
        public ObservableCollection<CanvasRings> RingList { get; set; }
        public ObservableCollection<CanvasRings> CanvasList { get; set; }
        public int BoardWidth = 3;

        public MainViewModel()
        {
            CanvasList = new ObservableCollection<CanvasRings>();
            RingList = new ObservableCollection<CanvasRings>();
            NewList(CanvasList, BoardWidth * BoardWidth);
            NewList(RingList, BoardWidth);


  //          RingSelection();
            RingSelectionCommand = new Command<string>(UpdateRing);
        }

        public void UpdateRing(string location)
        {
                        Debug.WriteLine("Clicked location " + location);

        }

        public void NewList(ObservableCollection<CanvasRings> list, int size) 
        {
            for (int x = 0; x < size; x++)
            {
                list.Add(new CanvasRings
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

       
        #region UI methods
        public void UpdateRing(MainViewModel box)
        {
            Debug.WriteLine("Entered UpdateRing for " + box.SmallColor.ToString());
            //       RingList[Location].SmallColor = Color.Yellow.ToSKColor();
        //     SKCanvasView view = MainPage.RingSelectionCanvas;
            //    SmallColor = Color.Yellow.ToSKColor();
            //      Debug.WriteLine("Entered UpdateRing for " + box.SmallColor.ToString());
        }
        #endregion
/*
        // For Visiblity an Alpha value of 0 is fully transparnt, and an alpha value of 0xFF is fully opaque.  
        public void RingSelection()
        {

        }
*/

    }
}
