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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Video_Editor
{
    /// <summary>
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This allows the file open dialog to select ffmpeg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //opens a file dialog to select where ffmpeg is
            OpenFileDialog dlgOpen = new OpenFileDialog();

            // set the default extension
            dlgOpen.DefaultExt = ".exe";

            // Show the Dialog
            Nullable<bool> bolResult = dlgOpen.ShowDialog();

            // get the result of selected file and stick it in textbox
            if (bolResult == true)
            {
                txtffmpegdir.Text = dlgOpen.FileName;
            }

            // if it contains ffmpeg release the button
            if (dlgOpen.FileName.ToUpper().Contains("FFMPEG"))
            {
                Defines.strFFMPEGDir = dlgOpen.FileName;
                btnContinue.IsEnabled = true;
            }


        }
    }
}
