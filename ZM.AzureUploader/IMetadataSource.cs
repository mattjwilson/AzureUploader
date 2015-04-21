﻿namespace ZM.AzureUploader
{
    using System.Threading.Tasks;
    using ZM.AzureUploader.Models;

    /// <summary>
    /// Defines the structure required of any object responsible for providing sourcing for the metadata surrounding the blobs being stored.
    /// </summary>
    public interface IMetadataSource
    {
        #region Methods

        /// <summary>
        /// Adds the metadata associated with a uploaded blob to the underlying table layer.
        /// </summary>
        /// <param name="data">A <see cref="Metadata"/> based object reprsenting the data to be saved.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        Task AddAsync(Metadata data);

        /// <summary>
        /// Finds the metadata for a given blob, searched by term or key.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value representing the term or key to be searched for.</param>
        /// <returns>A <see cref="Task{T}"/> based object returning a <see cref="Metadata"/> based object.</returns>
        Task<Metadata> FindAsync(string term);

        /// <summary>
        /// Removes a previously added metadata from the underlying storage.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value representing the key of the file to be removed.</param>
        /// <returns>A <see cref="Task{T}"/> based object returning a <see cref="Metadata"/> object represnting the data that was removed.</returns>
        Task<Metadata> RollbackAsync(string key);

        #endregion
    }
}
