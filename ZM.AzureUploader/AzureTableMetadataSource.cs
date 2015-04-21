namespace ZM.AzureUploader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZM.AzureUploader.Models;

    /// <summary>
    /// Responsible for managing the storage and retrieval of metadata for a blob in an azure table source.
    /// </summary>
    public class AzureTableMetadataSource : IMetadataSource
    {
        #region IMetadataSource members

        /// <summary>
        /// Adds the metadata associated with a uploaded blob to the underlying table layer.
        /// </summary>
        /// <param name="data">A <see cref="Metadata"/> based object reprsenting the data to be saved.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        public Task AddAsync(Metadata data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the metadata for a given blob, searched by term or key.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value representing the term or key to be searched for.</param>
        /// <returns>A <see cref="Task{T}"/> based object returning a <see cref="Metadata"/> based object.</returns>
        public Task<Metadata> FindAsync(string term)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a previously added metadata from the underlying storage.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value representing the key of the file to be removed.</param>
        /// <returns>A <see cref="Task{T}"/> based object returning a <see cref="Metadata"/> object represnting the data that was removed.</returns>
        public Task<Metadata> RollbackAsync(string key)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
