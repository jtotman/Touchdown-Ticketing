namespace Touchdown_Ticketing
{
    internal static class Constants
    {
        // Class to store relevant constant data such as MS SQL connection string, file paths, and 
        // sales tax; it is assumed that this is in Florida and can be adjusted as needed/wanted.
        public const string ConnectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER\\MSSQL\\DATA\\TouchdownTicketing.mdf\";Integrated Security=True;Connect Timeout=30";   
        public const string StadiumString = "C:\\Users\\Jon\\Desktop\\HCC\\HCC Summer\\COP 2939 - Capstone\\Touchdown Ticketing Layout.png";
        public const string IconString = "C:\\Users\\Jon\\Desktop\\HCC\\HCC Summer\\COP 2939 - Capstone\\Football Icon Touchdown Ticketing.ico";

        public const double SalesTax = 0.06;
    }
}
