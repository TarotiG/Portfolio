using Backend.Interfaces;

namespace Backend._Modules
{
    public  class SmtpSettings : ISettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public bool UseSsl { get; set; } = true;
    }
}
