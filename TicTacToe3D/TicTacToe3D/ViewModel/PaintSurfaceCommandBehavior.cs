using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TicTacToe3D.ViewModel
{
    public class PaintSurfaceCommandBehavior : Behavior<SKCanvasView>
    {
        // we need a bindable property for the command
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                nameof(Command),
                typeof(ICommand),
                typeof(PaintSurfaceCommandBehavior),
                null);

        // the command property
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // invoked immediately after the behavior is attached to a control
        protected override void OnAttachedTo(SKCanvasView bindable)
        {
            base.OnAttachedTo(bindable);

            // we want to be notified when the view's context changes
            bindable.BindingContextChanged += OnBindingContextChanged;
            // we are interested in the paint event
            bindable.PaintSurface += OnPaintSurface;
        }

        // invoked when the behavior is removed from the control
        protected override void OnDetachingFrom(SKCanvasView bindable)
        {
            base.OnDetachingFrom(bindable);

            // unsubscribe from all events
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.PaintSurface -= OnPaintSurface;
        }

        // the view's context changed
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            // update the behavior's context to match the view
            BindingContext = ((BindableObject)sender).BindingContext;
        }

        // the canvas needs to be painted
        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            // first check if the command can/should be fired
            if (Command?.CanExecute(e) == true)
            {
                // fire the command
                Command.Execute(e);
            }
        }
    }
}
