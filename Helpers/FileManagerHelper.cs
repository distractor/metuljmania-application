using System;
using System.IO;

namespace MetuljmaniaDatabase.Helpers
{
    public class FileManagerHelper
    {
        /// <summary>
        /// Uses date to create upload directory if it does not already exist.
        /// </summary>
        /// <param name="directory">Directory.</param>
        /// <param name="create">Create.</param>
        /// <returns></returns>
        public static string GetUploadDirectory(string directory, bool create = false)
        {
            var today = DateTime.UtcNow.Date;

            var path = Path.Combine(new[] { today.Year.ToString(), today.Month.ToString(), today.Day.ToString() });

            // Directory.
            if (!Directory.Exists(path) && create)
            {
                Directory.CreateDirectory(Path.Combine(new[] { directory, path }));
            }

            return path;
        }

        /// <summary>
        /// Remove file from storage.
        /// </summary>
        /// <param name="path">File path.</param>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                throw new Exception($"File at {path} could not be deleted because it does not exist.");
            }
        }
    }
}
