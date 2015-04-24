namespace ZM.AzureUploader
{
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the structure required of any object providing container factory / create services to the application.
    /// </summary>
    public interface IContainerFactory
    {
        #region Methods

        /// <summary>
        /// Creates and returns a new container used to access the underlying blob storage.
        /// </summary>
        /// <returns>A <see cref="CloudBlobContainer"/> based object.</returns>
        Task<CloudBlobContainer> CreateBlobContainer();

        /// <summary>
        /// Creates and returns a new table proxy used to access the underlying metadata store.
        /// </summary>
        /// <returns></returns>
        Task<CloudTable> CreateTableProxy();

        #endregion
    }
}
