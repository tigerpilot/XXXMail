using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Data;
using AutoMapper;
using api.ViewModel;
using System.Linq;

namespace api.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class MailSenderController : ControllerBase
    {
        private readonly XxxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMailer _mailer;

        public MailSenderController(IMailer mailer,XxxDbContext context,IMapper mapper){
            _mailer = mailer;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("msend")]
        public async Task<IActionResult> MailSender(string toAdress,string toName,string subject,string title,string subtitle){

            var posts = _context.Mails.ToList();

            var post = _mapper.Map<Mail,MailViewModel>(posts[0]);

            await  _mailer.Send(toAdress, toName, post.TemplateId, new
                {
                    Subject = subject,
                    Title = title,
                    Subtitle = subtitle
                });
            
            return Ok("mail sender works");
        }
    }
}