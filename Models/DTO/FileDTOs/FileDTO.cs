using System;

namespace MetuljmaniaDatabase.Models.DTO
{
    /// <summary>
    /// File DTO model.
    /// </summary>
    public class FileDTO
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// From user id.
        /// </summary>
        public int PilotId { get; set; }

        /// <summary>
        /// Uploaded date.
        /// </summary>
        public DateTime UploadedDate { get; set; }
    }
}
