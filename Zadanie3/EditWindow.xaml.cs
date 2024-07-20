using System.Windows;

namespace Zadanie3
{
    public partial class EditWindow : Window
    {
        public EditWindow(MediaItem mediaItem)
        {
            InitializeComponent();
            DataContext = mediaItem;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}