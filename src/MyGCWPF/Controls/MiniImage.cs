using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyGCWPF.Controls
{
    internal class MiniImage : Image
    {
        private bool IsDisposing { get; set; }

        MiniImage() 
        {
            Loaded += MiniImage_Loaded;
        }

        private void MiniImage_Loaded(object sender, RoutedEventArgs e)
        {
            VisibilityProperty.OverrideMetadata(typeof(MiniImage), new FrameworkPropertyMetadata((s, e) =>
            {
            }, (sender, value) =>
            {
                var visibility = (Visibility)value;
                switch (visibility)
                {
                    case Visibility.Hidden:
                    case Visibility.Collapsed:
                        IsDisposing = true;
                        Measure(new Size(0, 0));
                        Arrange(new Rect(0, 0, 0, 0));
                        break;
                    case Visibility.Visible:
                        IsDisposing = false;
                        InvalidateVisual();
                        break;
                }
                return visibility;
            }));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (IsDisposing) return;
        }
    }
}
