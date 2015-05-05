namespace ZM.AzureUploader
{
    using Microsoft.WindowsAzure.Storage.Table;
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
        #region Fields

        private readonly IContainerFactory factory;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="AzureTableMetadataSource"/> class.
        /// </summary>
        /// <param name="factory">An <see cref="IContainerFactor"/> capable of container instantiation.</param>
        public AzureTableMetadataSource(IContainerFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException("factory");

            this.factory = factory;
        }

        #endregion

        #region IMetadataSource members

        /// <summary>
        /// Adds the metadata associated with a uploaded blob to the underlying table layer.
        /// </summary>
        /// <param name="data">A <see cref="BlobMetadata"/> based object reprsenting the data to be saved.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        public async Task AddAsync(BlobMetadata data)
        {
            var table = await this.factory.CreateTableProxy();
            var insert = TableOperation.Insert(data.ToStorageMetadata());

            await table.ExecuteAsync(insert);
        }

        /// <summary>
        /// Finds the metadata for a given blob, searched by term or key.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value representing the term or key to be searched for.</param>
        /// <returns>A <see cref="Task{T}"/> based object returning a <see cref="BlobMetadata"/> based object.</returns>
        public async Task<BlobMetadata> FindAsync(string term)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a previously added metadata from the underlying storage.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value representing the key of the file to be removed.</param>
        /// <returns>A <see cref="Task{T}"/> based object returning a <see cref="BlobMetadata"/> object represnting the data that was removed.</returns>
        public async Task<BlobMetadata> RollbackAsync(string key)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
