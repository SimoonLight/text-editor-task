using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace text_editor_task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string _Text = "";
        public bool _HaveTxt = false;
        public bool _selectedall = false;
        public bool _avtosave = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                string fileContent = File.ReadAllText(selectedFileName);
                filename_place_txtbox.Text = selectedFileName;
                main_txtbox.Text = fileContent;
            }

        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {

            if (filename_place_txtbox.Text != "")
            {
                _file_works.Write_text(filename_place_txtbox.Text, main_txtbox.Text);
            }
        }

        private void cut_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this._selectedall == true)
            {
                main_txtbox.Text = "";
                this._selectedall = false;
            }
            else
            {
                main_txtbox.Cut();
                this._HaveTxt = false;

            }
        }

        private void copy_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this._selectedall == true)
            {
            this._selectedall = false;
            this._HaveTxt = true;
                this._Text = main_txtbox.Text;
            }
            else
            {

            this._selectedall = false;
            this._Text = main_txtbox.SelectedText;
            this._HaveTxt = true;
            }
        }

        private void paste_btn_Click(object sender, RoutedEventArgs e)
        {

            if (this._HaveTxt == true)
            {
                main_txtbox.Text += this._Text;
            }
        }

        private void selectAll_btn_Click(object sender, RoutedEventArgs e)
        {
            this._Text = main_txtbox.Text;
            this._HaveTxt = true;
            this._selectedall = true;
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked==false)
            {
            this._avtosave = true;

            }
            else
            {
                this._avtosave = false;
            }
        }

        private void main_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (filename_place_txtbox.Text != "")
            {
                _file_works.Write_text(filename_place_txtbox.Text, main_txtbox.Text);
            }
        }
    }
}