using Ordering.Application.Models;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Infrasructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
