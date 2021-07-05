using System;

namespace MetuljmaniaDatabase.Models.BlModel
{
    /// <summary>
    /// Pilot BL model.
    /// </summary>
    public class PilotBlModel
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// event id.
        /// </summary>
        public EventBlModel Event { get; set; }

        /// <summary>
        /// Female.
        /// </summary>
        public bool? Female { get; set; }

        /// <summary>
        /// Licence.
        /// </summary>
        public string Licence { get; set; }

        /// <summary>
        /// Fai licence.
        /// </summary>
        public string Fai { get; set; }

        /// <summary>
        /// Civl id.
        /// </summary>
        public string Civlid { get; set; }

        /// <summary>
        ///  Birthday.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Mobile phone.
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Flying since.
        /// </summary>
        public int? FlyingSince { get; set; }

        /// <summary>
        /// Team.
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
        /// Glider color.
        /// </summary>
        public string GliderColor { get; set; }

        /// <summary>
        /// Insurance company.
        /// </summary>
        public string InsuranceCompany { get; set; }

        /// <summary>
        /// Policy number.
        /// </summary>
        public string PolicyNumber { get; set; }

        /// <summary>
        /// Created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Modified date.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Sponsors.
        /// </summary>
        public string Sponsors { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Check file.
        /// </summary>
        public FileBlModel CheckFile { get; set; }

        /// <summary>
        /// IPPI card file.
        /// </summary>
        public FileBlModel IppiFile { get; set; }

        /// <summary>
        /// Licence file.
        /// </summary>
        public FileBlModel LicenceFile { get; set; }

        /// <summary>
        /// Signed application file.
        /// </summary>
        public FileBlModel SignedApplicationFile { get; set; }

        /// <summary>
        /// Unsigned application file.
        /// </summary>
        public FileBlModel UnSignedApplicationFile { get; set; }
    }
}
