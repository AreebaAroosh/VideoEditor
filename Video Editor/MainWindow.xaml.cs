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
            string strVideoLength;

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
            strVideoLength = Methods.strGetVideoDuration(dlgOpen.FileName);

            Defines.strVideoLength = strVideoLength;

            txtDuration.Text = strVideoLength;

            //set the drop down list for begining time.
            SetStartComboBoxes(strVideoLength);




        }

        private void SetStartComboBoxes(string strVideoLength)
        {
            TimeSpan timespan = TimeSpan.Parse(strVideoLength);

            int intHour = timespan.Hours;
            int intMin = 0;
            if (intHour == 0)
            {
                intMin = timespan.Minutes;
            }
            else
            {
                intMin = 59;
            }
            int intSec = timespan.Seconds;
            int intMSec = timespan.Milliseconds;

            ComboAddItem(intHour, cmbStartHour);
            ComboAddItem(intMin, cmbStartMin);
            ComboAddItem(59, cmbStartSec);
            ComboAddItem(59, cmbStartMs);



            ComboAddItem(59, cmbDurHour);
            ComboAddItem(59, cmbDurMin);
            ComboAddItem(59, cmbDurSec);
            ComboAddItem(59, cmbStartMs);
        }
       
        private void ComboAddItem(int length, ComboBox cmbBox)
        {
            for (int i = 0; i <= length; i++)
            {
                cmbBox.Items.Add(i);
            }
        }
    }
}
