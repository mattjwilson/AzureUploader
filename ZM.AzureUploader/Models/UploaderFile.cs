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
        /// Gets or sets a reference to an object containing the metadata around the blob being uploaded.
        /// </summary>
        public Metadata FileMetadata { get; set; }

        /// <summary>
        /// Gets or sets a reference to a value representing the actual file to be stored in blob storage.
        /// </summary>
        public MemoryStream File { get; set; }

        #endregion
    }
}
