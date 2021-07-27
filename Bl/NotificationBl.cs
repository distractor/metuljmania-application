﻿using AutoMapper;
using MetuljmaniaDatabase.DAL;
using MetuljmaniaDatabase.Helpers;
using MetuljmaniaDatabase.Models.BlModel;
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

        public async Task NotifyPilotsAsync(List<int>? pilotIds = null)
        {
            if (pilotIds == null)
            {
                var pilotsBlModel = await _pilotBl.GetPilotsAsync();
                pilotIds = pilotsBlModel.Select(p => p.Id).ToList();
            }

            foreach (var pilotId in pilotIds)
            {
                _ = NotifyPilotAsync(pilotId);
                Thread.Sleep(5000); // It is allowed to send ABOUT 20 mails per second.
            }
        }

        #endregion

        #region Private methods.

        private void NotifyPilot(PilotBlModel pilot)
        {
            _logger.Info($"Notifying pilot {pilot.Id}.");

            // Message.
            var subject = "Event registration form";
            var body = $"<h1>Hi, {pilot.FirstName} {pilot.LastName}!</h1><p>You registered for paragliding cross country competition <strong>{pilot.Event.Name}</strong>.</p><p>To speed up the registration process, we have developed a <strong><a href=\"http://89.142.194.106/\">web application</a></strong> where the registration process can be completed from your home couch. Please go to <strong><a href=\"http://89.142.194.106/application\">application page</a></strong> and use the password that was sent to you to reveal your personal data.</p><p><strong>Password: </strong>{pilot.Password}</p><p>Please check and correct your data. We kindly encorage you to upload scan or image of your IPPI card, licence and proof of airworthiness, otherwise you will have to show all of them at the registration. Once you complete, click the <strong>submit</strong> button and a PDF file with your data will be generated and sent to your email. You can then: <ul><li>Use your digital identity to sign it and <strong><a href=\"http://89.142.194.106/upload\">upload it back to our database</a></strong> or</li><li>bring a signed physical copy to the registration office.</li></ul></p><p>Thank you!</p>";

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
