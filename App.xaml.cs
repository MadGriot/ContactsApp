using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace ContactsApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static string databaseName = "Contacts.db";
    public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static string databasePath = Path.Combine(folderPath, databaseName);
}

