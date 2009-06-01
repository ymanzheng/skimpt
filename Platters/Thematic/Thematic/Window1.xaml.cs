using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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

namespace Thematic
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllDirs(Environment.SpecialFolder.MyDocuments.ToString());
            
        }

        private void GetAllDirs(string Path)
        {
            Console.WriteLine("Entering " + Path);

            //If has children
            if (Directory.GetDirectories(Path).Length > 0)
            {
                Console.WriteLine("Has children");
                //Create a new TVI for it
                TreeViewItem tvItem = new TreeViewItem();
                //Title it
                tvItem.Header = Path;

                //tvThemes.Items.Add(tvItem);

                string[] allThemes = Directory.GetDirectories(Path);

                foreach (string theme in allThemes)
                {
                    //Pass each child to the overloaded version of this method with the TVI
                    GetAllDirs(Path, tvItem, new TreeViewItem());
                }
            }
            //If it doesn't
            else
            {
                Console.WriteLine("No children");
                //Create a new TVI and add it to the list
                TreeViewItem tvi = new TreeViewItem();
                tvi.Header = Path;
                tvThemes.Items.Add(tvi);
            }
        }

        private void GetAllDirs(string Path, TreeViewItem parentTvItem, TreeViewItem childTvItem)
        {
            Console.WriteLine("Entering " + Path);
            //If the path has children
            if (Directory.GetDirectories(Path).Length > 0)
            {
                Console.WriteLine("Has children");
                childTvItem.Header = Path;
                parentTvItem.Items.Add(childTvItem);

                string[] allThemes = Directory.GetDirectories(Path);

                foreach (string theme in allThemes)
                {
                    //Pass each child to this method with the new tv item
                    GetAllDirs(theme, parentTvItem, new TreeViewItem());
                }

            }
            //If it doesn't
            else
            {
                Console.WriteLine("Has no children");
                tvThemes.Items.Add(parentTvItem);
            }
        }
    }
}
