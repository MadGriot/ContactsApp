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

namespace ContactsApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        NewContactWindow newContactWindow = new();
        newContactWindow.ShowDialog();

        //newContactWindow.Show(); allows you to use multiple windows.
    }
}