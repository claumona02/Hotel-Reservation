using System;
using Hotel.Data;
using System.IO;



namespace Hotel;

public partial class App : Application
{
    static ReservationListDatabase database;
    public static ReservationListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               ReservationListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ReservationList.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
