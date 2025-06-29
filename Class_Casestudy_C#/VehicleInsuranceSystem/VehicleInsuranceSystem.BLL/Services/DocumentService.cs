using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using VehicleInsuranceSystem.DAL.Models;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using System.IO;
using VehicleInsuranceSystem.BLL.Interfaces;

namespace VehicleInsuranceSystem.BLL.Services
{
    public class DocumentService : IDocumentService
    {
        public byte[] GeneratePolicyDocument(Policy policy)
        {
            using (var ms = new MemoryStream())
            {
                var document = new PdfDocument();
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                var font = new XFont("Verdana", 12, XFontStyle.Regular);

                gfx.DrawString("VEHICLE INSURANCE POLICY DOCUMENT", font, XBrushes.Black, new XRect(0, 20, page.Width, page.Height), XStringFormats.TopCenter);

                gfx.DrawString($"Policy ID: {policy.PolicyId}", font, XBrushes.Black, new XPoint(40, 80));
                gfx.DrawString($"User ID: {policy.PolicyProposal.UserId}", font, XBrushes.Black, new XPoint(40, 110));
                gfx.DrawString($"Vehicle Type: {policy.PolicyProposal.Vehicle.VehicleType}", font, XBrushes.Black, new XPoint(40, 140));
                gfx.DrawString($"Policy Start Date: {policy.StartDate:dd-MMM-yyyy}", font, XBrushes.Black, new XPoint(40, 170));
                gfx.DrawString($"Policy End Date: {policy.EndDate:dd-MMM-yyyy}", font, XBrushes.Black, new XPoint(40, 200));
                gfx.DrawString($"Premium Paid: ₹{policy.PremiumAmount}", font, XBrushes.Black, new XPoint(40, 230));
                gfx.DrawString($"Policy Status: {policy.Status}", font, XBrushes.Black, new XPoint(40, 260));

                document.Save(ms);
                return ms.ToArray();
            }
        }
    }
}
