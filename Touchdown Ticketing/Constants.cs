namespace Touchdown_Ticketing
{
    internal static class Constants
    {
        // Class to store relevant constant data such as MS SQL connection string and 
        // sales tax; it is assumed that this is in Florida and can be adjusted as needed/wanted.
        public const string ConnectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER\\MSSQL\\DATA\\TouchdownTicketing.mdf\";Integrated Security=True;Connect Timeout=30";
        public const double SalesTax = 0.06;
    }
}
