using System;

namespace MetuljmaniaDatabase.Models.BlModel
{
    /// <summary>
    /// Pilot BL model.
    /// </summary>
    public class PilotBlModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public bool? Female { get; set; }
        public string Licence { get; set; }
        public string Fai { get; set; }
        public string Civlid { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string Adress { get; set; }
        public int? FlyingSince { get; set; }
        public string Team { get; set; }
        public string Nation { get; set; }
        public string Glider { get; set; }
        public string SafetyClass { get; set; }
        public string GliderColor { get; set; }
        public string InsuranceCompany { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string[] Sponsors { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public  FileBlModel CheckFile { get; set; }
        public EventBlModel Event { get; set; }
        public FileBlModel IppiFile { get; set; }
        public FileBlModel LicenceFile { get; set; }
    }
}
