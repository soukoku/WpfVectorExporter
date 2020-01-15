using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFVectorExporter
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

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            var dlg = GetFolderDialog();

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ExportImages(dlg.FileName);
            }
        }

        private void ExportImages(string folder)
        {
            var sampleSize = vectorHolder.DataContext;
            foreach (var size in IconSize.TypicalSizes)
            {
                vectorHolder.DataContext = size;
                var fileName = System.IO.Path.Combine(folder, string.Format("favicon-{0}.png", size.Size));
                WriteOutImage(size.Size, vectorHolder, fileName);
            }
            vectorHolder.DataContext = sampleSize;
            Process.Start(folder);
        }

        private void WriteOutImage(int size, FrameworkElement vector, string fileName)
        {
            Size availableSize = new Size(size, size);
            vector.Measure(availableSize);
            vector.Arrange(new Rect(availableSize));

            RenderTargetBitmap bitmap = new RenderTargetBitmap(size, size, 96, 96, PixelFormats.Default);
            bitmap.Render(vector);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var fs = File.Create(fileName))
            {
                encoder.Save(fs);
            }
        }

        private static CommonOpenFileDialog GetFolderDialog()
        {
            var dlg = new CommonOpenFileDialog();
            dlg.Title = "Select Export Location";
            dlg.IsFolderPicker = true;
            //dlg.InitialDirectory = currentDirectory;

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            //dlg.DefaultDirectory = currentDirectory;
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;
            return dlg;
        }
    }
}
