namespace ZM.AzureUploader.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    /// <summary>
    /// Class representing a blob / file to be stored in azure storage.
    /// </summary>
    public class UploaderFile
    {
        #region Properties

        /// <summary>
        /// Gets or sets a reference to a value representing the name of the file to be stored.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets a reference to a value representing the user specified description (if available).
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a reference to a value representing the actual file to be stored in blob storage.
        /// </summary>
        public FileStream File { get; set; }

        /// <summary>
        /// Gets or sets a reference to a value representing the ip address of the client uploading the file.
        /// </summary>
        public string UploaderKey { get; set; }

        /// <summary>
        /// Gets or sets a reference to an object indicating when the original file was created / uploaded.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets a reference to an object indicatin when the last time the file was modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets a refernce to a value representing the key identifier for the entity that last modified the file.
        /// </summary>
        public string ModifiedByKey { get; set; }

        #endregion
    }
}
