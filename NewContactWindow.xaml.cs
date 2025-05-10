using ContactsApp.Models;
using SQLite;
using System.IO;
using System.Windows;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //Save contact and close Window
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };
            string databaseName = "Contacts.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string databasePath = Path.Combine(folderPath, databaseName);

            SQLiteConnection connection = new SQLiteConnection(databasePath);
            connection.CreateTable<Contact>();
            connection.Insert(contact);
            Close();

        }
    }
}
