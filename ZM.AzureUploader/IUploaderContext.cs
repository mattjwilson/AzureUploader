namespace ZM.AzureUploader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZM.AzureUploader.Models;

    /// <summary>
    /// Defines the structure required of objects capable of managing and accessing the azure components for storing the blob and metadata.
    /// </summary>
    public interface IUploaderContext
    {
        #region Methods

        /// <summary>
        /// Method capable of searching the indexed blob / metadata for a user specified file.
        /// </summary>
        /// <param name="searchKey">A <see cref="string"/> value representing the search key to use in matching the results.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> based collection of <see cref="UploaderFile"/> based objects.</returns>
        Task<IEnumerable<UploaderFile>> SearchAsync(string searchKey);

        /// <summary>
        /// Gets or sets a reference to an object representing a blob / file to be stored.
        /// </summary>
        /// <param name="blob"></param>
        /// <returns></returns>
        Task Add(UploaderFile blob);

        /// <summary>
        /// Method called to publish the current units of work to the remote storage containers.
        /// </summary>
        /// <returns>A <see cref="Task"/> based object.</returns>
        Task SaveAsync();

        #endregion
    }
}
