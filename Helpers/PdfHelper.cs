using MetuljmaniaDatabase.Models.BlModel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;

namespace MetuljmaniaDatabase.Helpers
{
    public class PdfHelper
    {
        public PdfHelper()
        {
            // https://stackoverflow.com/questions/50858209/system-notsupportedexception-no-data-is-available-for-encoding-1252/50875725
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public PdfDocument GenerateDocument(PilotBlModel pilot)
        {
            // Create a new PDF document.
            PdfDocument document = new();

            // Create an empty page.
            PdfPage page = document.AddPage();

            // Create fonts.
            XFont font = new("Times New Roman", 12, XFontStyle.Regular);
            XFont fontSmall = new("Times New Roman", 10, XFontStyle.Bold);
            XFont fontBold = new("Times New Roman", 12, XFontStyle.Bold);
            XFont fontHeader = new("Times New Roman", 18, XFontStyle.Bold);
            XFont fontItalic = new("Times New Roman", 12, XFontStyle.Italic);
            XFont fontFooter = new("Times New Roman", 10, XFontStyle.Italic);

            // Get an XGraphics object for drawing.
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // File.
            double x = 50, y = x;
            double ls = font.GetHeight();
            double ls_header = fontHeader.GetHeight();
            gfx.DrawString($"{pilot.Event.Name} - application form", fontHeader, XBrushes.Black, x, y);
            y += ls_header;
            XPen pen = new(XColors.Gray, 0.5);
            gfx.DrawLine(pen, page.Width * 0.5 - 200, y, page.Width * 0.5 + 200, y);
            y += 2 * ls_header;
            var y_initial = y;

            // Pilot details.
            gfx.DrawString("Pilot details:", fontHeader, XBrushes.Black, x, y);
            y += ls_header;
            // Name.
            gfx.DrawString("Name:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.FirstName} {pilot.LastName}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Gender.
            gfx.DrawString("Gender:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString(pilot.Female == true ? "Female" : "Male", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Birthday.
            gfx.DrawString("Birthday:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString(pilot.BirthDate?.ToString("dd-MM-yyy"), fontBold, XBrushes.Black, x, y);
            y += ls;
            // Address.
            gfx.DrawString("Address:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.Address}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Nation.
            gfx.DrawString("Nation:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.Nation}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Email.
            gfx.DrawString("Email:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.Email}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Mobile phone.
            gfx.DrawString("Mobile phone:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.MobilePhone}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Team.
            gfx.DrawString("Team:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.Team}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Sponsors.
            gfx.DrawString("Sponsors:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.Sponsors}", fontBold, XBrushes.Black, x, y);
            y += 2 * ls;

            // Insurance details.
            gfx.DrawString("Insurance details:", fontHeader, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString("Medical insurance, which includes paragliding competitions.", fontItalic, XBrushes.Black, x, y);
            y += ls;
            // Insurance company.
            gfx.DrawString("Insurance company:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.InsuranceCompany}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Policy number.
            gfx.DrawString("Policy number:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.PolicyNumber}", fontBold, XBrushes.Black, x, y);
            y += 2 * ls;

            // File upload details.
            gfx.DrawString("Uploaded files:", fontHeader, XBrushes.Black, x, y);
            y += ls_header;
            // Flying licence.
            gfx.DrawString("Licence:", fontSmall, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString(pilot.LicenceFile != null ?
            $"Yes, {pilot.LicenceFile.Path} uploaded on {pilot.LicenceFile.UploadedDate}." : "Missing", fontBold, XBrushes.Black, x, y);
            y += ls;
            // IPPI.
            gfx.DrawString("IPPI card:", fontSmall, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString(pilot.IppiFile != null ?
              $"Yes, {pilot.IppiFile.Path} uploaded on {pilot.IppiFile.UploadedDate}." : "Missing", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Glider check.
            gfx.DrawString("Glider check:", fontSmall, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString(pilot.CheckFile != null ?
             $"Yes, {pilot.CheckFile.Path} uploaded on {pilot.CheckFile.UploadedDate}." : "Missing", fontBold, XBrushes.Black, x, y);
            y += 2 * ls;

            // Responsibility.
            gfx.DrawString("Responsibilty:", fontHeader, XBrushes.Black, x, y);
            y += ls_header;
            gfx.DrawString("Participation in this competition is at the sole responsibility of each individual pilot.", fontItalic, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString("The event organizer does not claim any responsibility for the pilots or other third parties.", fontItalic, XBrushes.Black, x, y);
            y += 2 * ls_header;

            // Pilot signature.
            gfx.DrawString("Pilot signature:", fontBold, XBrushes.Black, x, y);
            // Meet director siganture.
            gfx.DrawString("Meet director signature:", fontBold, XBrushes.Black, page.Width - 200, y);

            // Flying details.
            y = y_initial;
            x = page.Width * 0.5;
            gfx.DrawString("Flying:", fontHeader, XBrushes.Black, x, y);
            y += ls_header;
            // National licence.
            gfx.DrawString("National licence ID:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.Licence}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Flying since.
            gfx.DrawString("Flying since:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.FlyingSince}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // CIVL ID.
            gfx.DrawString("CIVL ID:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.Civlid}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // FAI number.
            gfx.DrawString("FAI number:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.Fai}", fontBold, XBrushes.Black, x, y);
            y += ls;

            // Glider.
            gfx.DrawString("Glider:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.Glider}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Glider color.
            gfx.DrawString("Glider color:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.GliderColor}", fontBold, XBrushes.Black, x, y);
            y += ls;
            // Glider safety.
            gfx.DrawString("Glider safety class:", font, XBrushes.Black, x, y);
            y += ls;
            gfx.DrawString($"{pilot.SafetyClass}", fontBold, XBrushes.Black, x, y);

            // Footer.
            gfx.DrawString($"This file has been automatically generated by Metuljmania application. Generated on {DateTime.Now}.", fontFooter, XBrushes.Gray, 50, page.Height - 25);

            return document;
        }
    }
}
