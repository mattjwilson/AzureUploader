namespace ZM.AzureUploader
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using ZM.AzureUploader.Models;

    /// <summary>
    /// Class responsible for storing and retrieving blobs from an azure storage source.
    /// </summary>
    public class AzureBlobSource : IBlobSource
    {
        #region Fields

        private readonly IContainerFactory factory;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="AzureBlobSource"/> class, requiring 
        /// </summary>
        /// <param name="factory">An <see cref="IContainerFactory"/> based object capable of providing the proxy clients required to acess the underlying data store.</param>
        public AzureBlobSource(IContainerFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException("factory");

            this.factory = factory;
        }

        #endregion

        #region Methods
        #endregion

        #region IBlobSource members

        /// <summary>
        /// Method called to add a new blob to the underlying storage.
        /// </summary>
        /// <param name="file">A <see cref="UploaderFile"/> based object representing the object being stored.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        public async Task UploadAsync(UploaderFile file)
        {
            var container = await this.factory.CreateBlobContainer();
            var blob = container.GetBlockBlobReference(file.FileMetadata.FileName);

            await blob.UploadFromStreamAsync(file.File);
        }

        /// <summary>
        /// Retrieves a blob from the remote Azure store.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value represnting the key of the blob to retrieve.</param>
        /// <returns>A <see cref="Task{T}"/> based object returning a <see cref="MemoryStream"/> based object.</returns>
        public async Task<MemoryStream> FindAsync(string key)
        {
            var container = await this.factory.CreateBlobContainer();
            var blob = container.GetBlockBlobReference(key);

            MemoryStream stream = new MemoryStream();
            await blob.DownloadToStreamAsync(stream);

            // potentially not return memorystream here.  Can i guarantee it's disposal?
            // http://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs/
            return stream;
        }

        /// <summary>
        /// Removes a previously submiteted and saved blob element.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        public async Task RollbackAsync(string key)
        {
            var container = await this.factory.CreateBlobContainer();
            var blob = container.GetBlockBlobReference(key);
            await blob.DeleteAsync();
        }

        #endregion
    }
}
