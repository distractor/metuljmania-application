using System;

namespace MetuljmaniaDatabase.Models.BlModel
{
    /// <summary>
    /// File BL model.
    /// </summary>
    public class FileBlModel
    {
        /// <summary>
        ///  Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// From pilot id.
        /// </summary>
        public int PilotId { get; set; }

        /// <summary>
        /// Uploaded date.
        /// </summary>
        public DateTime UploadedDate { get; set; }
    }
}
