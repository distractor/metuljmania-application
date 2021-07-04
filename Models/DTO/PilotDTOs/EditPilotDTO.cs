using System;

namespace MetuljmaniaDatabase.Models.DTO
{
    public class EditPilotDTO
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Event.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Is female.
        /// </summary>
        public bool? Female { get; set; }

        /// <summary>
        /// Pilot license.
        /// </summary>
        public string Licence { get; set; }

        /// <summary>
        /// Fai license.
        /// </summary>
        public string Fai { get; set; }

        /// <summary>
        /// CIVL id.
        /// </summary>
        public string Civlid { get; set; }

        /// <summary>
        /// Birthday.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Mobile phone.
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Adress.
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Flying since.
        /// </summary>
        public int? FlyingSince { get; set; }

        /// <summary>
        ///  Team/club.
        /// </summary>
        public string Team { get; set; }

        /// <summary>
        /// Nation.
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// Glider.
        /// </summary>
        public string Glider { get; set; }

        /// <summary>
        /// Safety class.
        /// </summary>
        public string SafetyClass { get; set; }

        /// <summary>
        ///  Glider color.
        /// </summary>
        public string GliderColor { get; set; }

        /// <summary>
        /// Insurance company.
        /// </summary>
        public string InsuranceCompany { get; set; }

        /// <summary>
        /// Insurance policy number.
        /// </summary>
        public string PolicyNumber { get; set; }

        /// <summary>
        /// IPPI card file.
        /// </summary>
        public int? IppifileId { get; set; }

        /// <summary>
        /// Licence file.
        /// </summary>
        public int? LicenceFileId { get; set; }

        /// <summary>
        /// Glider check file.
        /// </summary>
        public int? CheckFileId { get; set; }

        /// <summary>
        /// Sponsor list.
        /// </summary>
        public string Sponsors { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }
    }
}
