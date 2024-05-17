namespace AdoRelation.Helper
{
    public static class ConnectionString
    {
        private static string cs = "Server=DESKTOP-0Q1MPN4\\SQLEXPRESS;Database=adorelation;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        public static string dbcs { get => cs; }

    }
}
