using AutoMapper;
using MetuljmaniaDatabase.DAL;
using MetuljmaniaDatabase.Helpers;
using MetuljmaniaDatabase.Models.BlModel;
using MetuljmaniaDatabase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.Bl
{
    public class NotificationBl : BaseBl, INotificationBL
    {
        private readonly IPilotBl _pilotBl;
        private readonly NotificationHelper _client = new();

        public NotificationBl(IMapper mapper, IPrincipal principal, IBaseDAL baseDAL, IPilotBl pilotBl) : base(mapper, principal)
        {
            _pilotBl = pilotBl;
        }

        #region Public methods.

        public async Task NotifyPilotAsync(int pilotId)
        {
            // Get pilot BL model.
            var pilotBLModel = await _pilotBl.GetPilotAsync(pilotId);
            // Send notification.
            NotifyPilot(pilotBLModel);
        }

        public async Task<NotificationSummaryDTO> NotifyPilotsAsync(List<int>? pilotIds = null)
        {
            if (pilotIds == null)
            {
                var pilotsBlModel = await _pilotBl.GetPilotsAsync();
                pilotIds = pilotsBlModel.Select(p => p.Id).ToList();
            }

            var notificationSummary = new NotificationSummaryDTO
            {
                PilotIds = pilotIds
            };
            var pilotIdsSent = new List<int>();
            foreach (var pilotId in pilotIds)
            {
                _ = NotifyPilotAsync(pilotId);
                pilotIdsSent.Add(pilotId);
                Thread.Sleep(5000); // It is allowed to send ABOUT 20 mails per second.
            }
            notificationSummary.PilotIdsSent = pilotIdsSent;

            // Check success status.
            notificationSummary.Success = true;
            foreach (var pilotId in pilotIds)
            {
                notificationSummary.Success = notificationSummary.Success && notificationSummary.PilotIdsSent.Any(id => id == pilotId);
            }

            return notificationSummary;
        }

        #endregion

        #region Private methods.

        private void NotifyPilot(PilotBlModel pilot)
        {
            _logger.Info($"Notifying pilot {pilot.Id}.");

            // Message.
            var subject = "Event registration form";
            var body = $"<h1>Hi, {pilot.FirstName} {pilot.LastName}!</h1><p>You registered for paragliding cross country competition <strong>{pilot.Event.Name}</strong>.</p><p>To speed up the registration process, we have developed a web application where the registration process can be completed from your home couch. Please go to <strong><a href=\"http://register.metuljmania.com\">application page</a></strong> and use the password that was sent to you to reveal your personal data.</p><p><strong>Password: </strong>{pilot.Password}</p><p>Please check and correct your data. We kindly encourage you to upload scan or image of your IPPI card, licence and proof of airworthiness, otherwise you will have to show all of them on the spot. Once you complete, click the <strong>submit</strong> button and a PDF file with your data will be generated, stored to our database and sent to your email.</p><p>Thank you!</p>";

            // Send message.
            try
            {
                _client.Send(pilot.Email, subject, body);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong wile sending email to {pilot.Email}.");
                throw new Exception($"Something went wrong wile sending email to {pilot.Email}. Exception details: ${ex.Message}.");
            }
        }

        #endregion
    }
}
