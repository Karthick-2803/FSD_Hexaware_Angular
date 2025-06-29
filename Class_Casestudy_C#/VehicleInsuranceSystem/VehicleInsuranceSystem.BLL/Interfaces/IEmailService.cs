using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsuranceSystem.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailWithAttachmentAsync(string toEmail, string subject, string body, byte[] attachmentBytes, string fileName);
    }

}
