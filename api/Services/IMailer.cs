using System.Threading.Tasks;

namespace api.Services
{
     public interface IMailer
    {
        public Task Send(string emailAddress,string userFullname,string templateId,object data);
    }
}