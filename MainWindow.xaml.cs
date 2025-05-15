using ContactsApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace ContactsApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    List<Contact> contacts;
    public MainWindow()
    {
        InitializeComponent();
        contacts = new List<Contact>();
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

        using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
        {
            conn.CreateTable<Contact>();
            contacts = conn.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
        }

        if (contacts != null)
        {
            contactsListView.ItemsSource = contacts;
        }
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox searchTextBox = sender as TextBox;

        List<Contact> filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

        contactsListView.ItemsSource = filteredList;
    }

    private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Contact selectedContact = (Contact)contactsListView.SelectedItem;

        if (selectedContact != null)
        {
            ContactDetailsWindow contactDetailsWindow = new(selectedContact);
            contactDetailsWindow.ShowDialog();
        }

        ReadDatabase();
    }
}