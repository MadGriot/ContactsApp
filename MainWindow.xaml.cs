using ContactsApp.Models;
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
        InitializeComponent();
        ReadDatabase();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        NewContactWindow newContactWindow = new();
        newContactWindow.ShowDialog();

        //newContactWindow.Show(); allows you to use multiple windows.

        ReadDatabase();
    }

    void ReadDatabase()
    {
        List<Contact> contacts;
        using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
        {
            conn.CreateTable<Contact>();
            contacts = conn.Table<Contact>().ToList();
        }

        if (contacts != null)
        {
            contactsListView.ItemsSource = contacts;
        }
    }
}