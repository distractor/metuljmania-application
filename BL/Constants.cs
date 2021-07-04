using MetuljmaniaDatabase.Providers;
using Microsoft.Extensions.Configuration;

namespace MetuljmaniaDatabase.Logic
{
    public static class Constants
    {
        private static readonly IConfigurationSection s_appSettings = ConfigProvider.Configuration.GetSection("AppSettings");
        private static readonly IConfigurationSection s_uploadSettings = ConfigProvider.Configuration.GetSection("Upload");
        private static readonly IConfigurationSection s_createdSettings = ConfigProvider.Configuration.GetSection("Created");
        private static readonly IConfigurationSection s_metuljmania = ConfigProvider.Configuration.GetSection("MetuljmaniaSettings");
        private static readonly IConfigurationSection s_notification = ConfigProvider.Configuration.GetSection("Notification");

        // App settings.
        public static readonly string Secret = s_appSettings["Secret"];
        public static readonly string uploadDirectory = s_uploadSettings["Directory"];
        public static readonly string createdDirectory = s_createdSettings["Directory"];

        // Glista settings.
        public static readonly string DecimalSeparator = s_metuljmania["DecimalSeparator"];
        public static readonly string GroupSeparator = s_metuljmania["GroupSeparator"];
        public static readonly int PasswordLength = int.Parse(s_metuljmania["PasswordLength"]);

        // Notification settings.
        public static readonly string Host = s_notification["Host"];
        public static readonly string GmailPassword = s_notification["Password"];
        public static readonly string FromAddress = s_notification["FromAddress"];
        public static readonly int Port = int.Parse(s_notification["Port"]);
        public static readonly int Timeout = int.Parse(s_notification["Timeout"]);
        public static readonly bool EnableSsl = bool.Parse(s_notification["EnableSsl"]);
    }
}
