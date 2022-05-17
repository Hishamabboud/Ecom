namespace Ecommerence.Settings
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public TokenSettings TokenSettings { get; set; }

        public AppSettings()
        {
            TokenSettings = new TokenSettings();
        }

    }
}
