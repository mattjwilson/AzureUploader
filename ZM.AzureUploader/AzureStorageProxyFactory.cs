namespace ZM.AzureUploader
{
    using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// Class responsible for building the objects required to access the Azure storage layer.
    /// </summary>
    public class AzureStorageProxyFactory : IContainerFactory
    {
        #region Fields

        private readonly IUploadSettings settings;

        #endregion

        #region Members

        private CloudStorageAccount BuildAccount()
        {
            var account = CloudStorageAccount.Parse(this.settings.BlobConnectionString);
            return account;
        }

        #endregion

        #region IContainerFactory members

        /// <summary>
        /// Creates and returns a new container used to access the underlying blob storage.
        /// </summary>
        /// <returns>A <see cref="CloudBlobContainer"/> based object.</returns>
        public async Task<CloudBlobContainer> CreateBlobContainer()
        {
            var account = CloudStorageAccount.Parse(this.settings.BlobConnectionString);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(this.settings.BlobContainerName);
            await container.CreateIfNotExistsAsync();
            return container;
        }

        /// <summary>
        /// Creates and returns a new table proxy used to access the underlying metadata store.
        /// </summary>
        /// <returns></returns>
        public async Task<CloudTable> CreateTableProxy() 
        {
            var account = CloudStorageAccount.Parse(this.settings.MetadataConnectionString);
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference("metadata");
            
            await table.CreateIfNotExistsAsync();

            return table;
        }

        #endregion
    }
}
