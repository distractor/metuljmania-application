using System;
using System.ComponentModel.DataAnnotations;

namespace MetuljmaniaDatabase.Models.DTO
{
    public class BasicInfoDTO
    {
        public BasicInfoDTO()
        {
        }

        public BasicInfoDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Range(1, int.MaxValue, ErrorMessage = "Id should be larger than 0.")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
