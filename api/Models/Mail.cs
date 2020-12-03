
namespace api
{
    public class Mail
    {
        public int Id { get; set; }
        public string ToWhom { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string TemplateId { get; set; }
        public string ApiKey { get; set; }
    }
}