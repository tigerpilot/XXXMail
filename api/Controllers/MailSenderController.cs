using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Data;
using AutoMapper;
using api.ViewModel;
using System.Linq;
using Microsoft.AspNetCore.Cors;

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

        [EnableCors("Policy1")]
        [HttpPost]
        [Route("msend")]
        public async Task<IActionResult> MailSender(SendingDataViewModel model){

            var posts = _context.Mails.ToList();

            var post = _mapper.Map<Mail,MailViewModel>(posts[0]);

            await  _mailer.Send(model.ToMailAdr, model.ToName, post.TemplateId, new
                {
                    Subject = model.Subject,
                    Title = model.Title,
                    Subtitle = model.SubTitle
                });
            
            return Ok();
        }
    }
}