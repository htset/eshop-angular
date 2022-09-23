namespace eshop_backend.Helpers
{
    public class AppSettings
    {
        public string? Secret { get; set; }
        public string? SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string? SmtpUsername { get; set; }
        public string? SmtpPassword { get; set; }
    }
}
