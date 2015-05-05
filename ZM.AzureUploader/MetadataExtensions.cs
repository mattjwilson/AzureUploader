namespace ZM.AzureUploader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using ZM.AzureUploader.Models;

    /// <summary>
    /// Extension methods for the <see cref="BlobMetadata"/> class.
    /// </summary>
    internal static class MetadataExtensions
    {
        internal static StorageMetadata ToStorageMetadata(this BlobMetadata data)
        {
            var metadata = new StorageMetadata
            {
                CreatedDate = data.CreatedDate,
                Description = data.Description,
                FileName = data.FileName,
                IsPrivate = data.IsPrivate,
                ModifiedByKey = data.ModifiedByKey,
                ModifiedDate = data.ModifiedDate,
                SharedKey = data.SharedKey,
                UploaderKey = data.UploaderKey
            };

            return metadata;
        }
    }
}
