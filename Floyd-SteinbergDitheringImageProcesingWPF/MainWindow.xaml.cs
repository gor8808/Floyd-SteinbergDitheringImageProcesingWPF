using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Floyd_SteinbergDitheringImageProcesingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string Path;
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NormalImageField.Source == null)
            {
                return;
            }
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Path);
            bitmap.EndInit();
            WriteableBitmap writeableBitmap = new WriteableBitmap(bitmap);

            for (int x = 0; x < writeableBitmap.Width; x++)
            {
                for (int y = 0; y < writeableBitmap.Height; y++) 
                {
                    Color pixel = writeableBitmap.GetPixel(x, y);
                    float r = pixel.R;
                    float g = pixel.G;
                    float b = pixel.B;
                    r = (float)Math.Round(r / 255) * 255;
                    g = (float)Math.Round(g / 255) * 255;
                    b = (float)Math.Round(b / 255) * 255;
                    writeableBitmap.SetPixel(x, y, Color.FromRgb((byte)r, (byte)g, (byte)b));
                }

            }
            ProcessedImageField.Source = writeableBitmap;


        }

        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Path = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path);
                bitmap.EndInit();
                NormalImageField.Source = bitmap;
            }

        }

        private void SaveImageBtn_Click(object sender, RoutedEventArgs e)
        {
            ProcessedImageField.Source
        }
    }
}
