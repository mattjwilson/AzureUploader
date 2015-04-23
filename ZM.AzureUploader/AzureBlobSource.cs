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

        private readonly IUploadSettings settings;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="AzureBlobSource"/> class, requiring 
        /// </summary>
        /// <param name="settings">An <see cref="IUploadSettings"/> based object capable of providing the information needed to connect to the Azure blob storage.</param>
        public AzureBlobSource(IUploadSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");

            this.settings = settings;
        }

        #endregion

        #region Methods

        private CloudBlobContainer BuildBlobContainer()
        {
            var account = CloudStorageAccount.Parse(this.settings.BlobConnectionString);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(this.settings.BlobContainerName);

            return container;
        }

        #endregion

        #region IBlobSource members

        /// <summary>
        /// Method called to add a new blob to the underlying storage.
        /// </summary>
        /// <param name="file">A <see cref="UploaderFile"/> based object representing the object being stored.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        public async Task UploadAsync(UploaderFile file)
        {
            var container = this.BuildBlobContainer();
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
            var container = this.BuildBlobContainer();
            var blob = container.GetBlockBlobReference(key);

            MemoryStream stream = new MemoryStream();
            await blob.DownloadToStreamAsync(stream);

            // potentially not return memorystream here.  Can i guarantee it's disposal?
            // http://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs/
            return stream;
        }

        #endregion
    }
}
