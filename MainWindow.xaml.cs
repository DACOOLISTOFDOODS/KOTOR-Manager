using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace KOTOR_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public void play(string name)
        {
            if (File.ReadAllText(cfgpath).Contains("music=0")) { return; }

            Uri uri = new Uri("\\Assets\\" + name + ".WAV", UriKind.Relative);
            StreamResourceInfo info = System.Windows.Application.GetResourceStream(uri);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(info.Stream);
            player.Play();
        }
        
        string cfgpath = AppDomain.CurrentDomain.BaseDirectory + "\\config.ini";
        //states what game is currently selected from the radio buttons in the mods tab
        int modgame = 0;
        //to stop tab sound from playing when app starts
        int tabstarted = 0;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainLoaded;
        }
        
        private void MainLoaded(object sender, RoutedEventArgs e)
        {
            if(!File.Exists(cfgpath))
            {
                File.WriteAllText(cfgpath, "music=1\nk1=\"\"\nk2=\"\"");
            }
            if(File.ReadAllText(cfgpath).Contains("music=1")) { musicBox.IsChecked = true; }

            //replace options path text with ini text

            play("open");
        }
        
        private void launch1_Click(object sender, RoutedEventArgs e)
        {
            //launch kotor 1
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabstarted == 0)
            {
                tabstarted = 1;
                return;
            }

            play("big");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void loose_inst_Click(object sender, RoutedEventArgs e)
        {
            //if no game is selected in radio buttons
            //add integration with different installations
            if(modgame == 0) //or path of selected game is not given in options tab
            {
                System.Windows.MessageBox.Show("Select a game before trying to install a mod.");
                return;
            }
            
            string path;
            DialogResult result;
            do
            {
                System.Windows.Forms.FolderBrowserDialog loose = new System.Windows.Forms.FolderBrowserDialog();
                result = loose.ShowDialog();
                path = loose.SelectedPath;
            } while (result != System.Windows.Forms.DialogResult.OK);
            loose_inst.Content = path;
        }

        private void RadioButtonModK1_Checked(object sender, RoutedEventArgs e)
        {
            modgame = 1;
        }

        private void RadioButtonModK2_Checked(object sender, RoutedEventArgs e)
        {
            modgame = 2;
        }

        private void MusicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(cfgpath, File.ReadAllText(cfgpath).Replace("music=0", "music=1"));
        }

        private void MusicCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(cfgpath, File.ReadAllText(cfgpath).Replace("music=1", "music=0"));
        }

        private void browse_k1_click(object sender, RoutedEventArgs e)
        {
            string path = "";
            DialogResult result;
            OpenFileDialog k1path = new OpenFileDialog();
            k1path.Filter = "swkotor.ini|swkotor.ini";
            do
            {
                result = k1path.ShowDialog();
                path = k1path.FileName.Substring(0, k1path.FileName.Length - 12);
            } while (path.Length < 1);
            k1_txt.Text = path;

            //why doesnt this do anything
            string ini = File.ReadAllText(cfgpath);
            ini = ini.Replace("k1=\"*\"", "k1=\"" + path + "\"");
            File.WriteAllText(cfgpath, ini);
        }

        private void browse_k2_click(object sender, RoutedEventArgs e)
        {
            string path = "";
            DialogResult result;
            OpenFileDialog k2path = new OpenFileDialog();
            k2path.Filter = "swkotor2.ini|swkotor2.ini";
            do
            {
                result = k2path.ShowDialog();
                path = k2path.FileName.Substring(0, k2path.FileName.Length - 13);
            } while (path.Length < 1);
            k2_txt.Text = path;

            //why doesnt this do anything
            string ini = File.ReadAllText(cfgpath);
            ini = ini.Replace("k2=\"*\"", "k2=\"" + path + "\"");
            File.WriteAllText(cfgpath, ini);
        }

        private void k1_txt_LostFocus(object sender, RoutedEventArgs e)
        {
            //write to ini
        }

        private void k2_txt_LostFocus(object sender, RoutedEventArgs e)
        {
            //write to ini
        }
    }
}
