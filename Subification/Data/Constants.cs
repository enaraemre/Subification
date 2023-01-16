namespace SUBIFICATION.Data;

public static class Constants
{
    public const string DatabaseFilename = "Subification2.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath => 
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

    public static string ServiceUri = "https://demo-datasync-quickstart.azurewebsites.net";

    /// <summary>
    /// The application (client) ID for the native app within Azure Active Directory
    /// </summary>
    public static string ApplicationId = "<ea8eb6fe-dbf7-4641-bfe5-3ed957193f1a>";

    /// <summary>
    /// The list of scopes to request
    /// </summary>
    public static string[] Scopes = new[]
    {
          "<access_as_user>"
      };
}
