namespace ZM.AzureUploader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class responsible for storing and retrieving blobs from an azure storage source.
    /// </summary>
    public class AzureBlobSource : IBlobSource
    {
        #region IBlobSource members

        /// <summary>
        /// Method called to add a new blob to the underlying storage.
        /// </summary>
        /// <param name="blob">A <see cref="MemoryStream"/> based object representing the object being stored.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        public async Task UploadAsync(MemoryStream blob)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a blob from the remote Azure store.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value represnting the key of the blob to retrieve.</param>
        /// <returns>A <see cref="Task{T}"/> based object returning a <see cref="MemoryStream"/> based object.</returns>
        public async Task<MemoryStream> FindAsync(string key)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
