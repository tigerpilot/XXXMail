using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using api.Data;
using System.Linq;
using AutoMapper;
using api.ViewModel;

namespace api.Services
{
    public class Mailer : IMailer
    {

        private readonly XxxDbContext _context;
        private readonly IMapper _mapper;

        public Mailer(XxxDbContext context,IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        public async Task Send(string emailAddress, string userFullname, string templateId, object data)
        {
            var posts = _context.Mails.ToList();

            var post = _mapper.Map<Mail,MailViewModel>(posts[0]);


            var client = new SendGridClient(post.ApiKey);
            var SendGridMessage = new SendGridMessage();
            SendGridMessage.SetFrom(post.SenderEmail,post.SenderName);
            SendGridMessage.AddTo(emailAddress, userFullname);
            SendGridMessage.SetTemplateId(templateId);
            SendGridMessage.SetTemplateData(data);

           var response = await client.SendEmailAsync(SendGridMessage);

        }
    }
}