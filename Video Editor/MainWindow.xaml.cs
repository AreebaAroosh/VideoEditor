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
using Microsoft.Win32;


namespace Video_Editor
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

        /// <summary>
        /// Gets the video file selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVideoSelector_Click(object sender, RoutedEventArgs e)
        {
            //opens a file dialog to select where ffmpeg is
            OpenFileDialog dlgOpen = new OpenFileDialog();

            // Show the Dialog
            Nullable<bool> bolResult = dlgOpen.ShowDialog();

            // get the result of selected file and stick it in textbox
            if (bolResult == true)
            {
                txtVideoFile.Text = dlgOpen.FileName;
            }

            // Save original file path and name
            Defines.strOrigVideoFile = dlgOpen.FileName;

            // now we will run a prob on it to test the duration of it
            
        }

       
    }
}
