using MetuljmaniaDatabase.Providers;
using Microsoft.Extensions.Configuration;

namespace MetuljmaniaDatabase.Logic
{
    public static class Constants
    {
        private static readonly IConfigurationSection s_appSettings = ConfigProvider.Configuration.GetSection("AppSettings");
        private static readonly IConfigurationSection s_uploadSettings = ConfigProvider.Configuration.GetSection("Upload");
        private static readonly IConfigurationSection s_createdSettings = ConfigProvider.Configuration.GetSection("Created");
        private static readonly IConfigurationSection s_metuljmania= ConfigProvider.Configuration.GetSection("MetuljmaniaSettings");

        // App settings.
        public static readonly string Secret = s_appSettings["Secret"];
        public static readonly string uploadDirectory = s_uploadSettings["Directory"];
        public static readonly string createdDirectory = s_createdSettings["Directory"];

        // Glista settings.
        public static readonly string DecimalSeparator = s_metuljmania["DecimalSeparator"];
        public static readonly string GroupSeparator = s_metuljmania["GroupSeparator"];
    }
}
