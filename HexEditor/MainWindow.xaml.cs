using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HexEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ReadBytesOptions options = new ReadBytesOptions();

        public MainWindow()
        {
            InitializeComponent();
            
           (WfHost.Child as PropertyGrid).SelectedObject = options;

            var commandBinding = new CommandBinding
            {
                Command = ApplicationCommands.Open
            };
            commandBinding.Executed += OpenFileCommandExecuted;
            OpenMenuItem.CommandBindings.Add(commandBinding);
        }

        private void OpenFileCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Open File");
        }
    }
}
