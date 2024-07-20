using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Zadanie3
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<MediaItem> MediaItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MediaItems = new ObservableCollection<MediaItem>();
            DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var mediaItem = new MediaItem();
            var editWindow = new EditWindow(mediaItem);
            if (editWindow.ShowDialog() == true)
            {
                MediaItems.Add(mediaItem);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (MediaDataGrid.SelectedItem is MediaItem selectedMediaItem)
            {
                var editWindow = new EditWindow(selectedMediaItem);
                editWindow.ShowDialog();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MediaDataGrid.SelectedItem is MediaItem selectedMediaItem)
            {
                MediaItems.Remove(selectedMediaItem);
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<MediaItem>));
                    using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        var importedItems = (ObservableCollection<MediaItem>)serializer.Deserialize(stream);
                        MediaItems.Clear();
                        foreach (var item in importedItems)
                        {
                            MediaItems.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas importowania: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<MediaItem>));
                    using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        serializer.Serialize(stream, MediaItems);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas eksportowania: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}