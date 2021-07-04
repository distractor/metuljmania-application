﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace MetuljmaniaDatabase.Models.DbModels
{
    public partial class File
    {
        public File()
        {
            PilotCheckFile = new HashSet<Pilot>();
            PilotIppiFile = new HashSet<Pilot>();
            PilotLicenceFile = new HashSet<Pilot>();
        }

        public int Id { get; set; }
        public string Path { get; set; }
        public int PilotId { get; set; }
        public DateTime UploadedDate { get; set; }

        public virtual Pilot Pilot { get; set; }
        public virtual ICollection<Pilot> PilotCheckFile { get; set; }
        public virtual ICollection<Pilot> PilotIppiFile { get; set; }
        public virtual ICollection<Pilot> PilotLicenceFile { get; set; }
    }
}