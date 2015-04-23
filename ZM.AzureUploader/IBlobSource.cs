namespace ZM.AzureUploader
{
    using System.IO;
    using System.Threading.Tasks;
    using ZM.AzureUploader.Models;

    /// <summary>
    /// Defines the structure required of any object providing sourcing services for the actual blob storage.
    /// </summary>
    public interface IBlobSource
    {
        #region Methods

        /// <summary>
        /// Method called to add a new blob to the underlying storage.
        /// </summary>
        /// <param name="file">A <see cref="UploaderFile"/> based object representing the object being stored.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        Task UploadAsync(UploaderFile file);

        /// <summary>
        /// Retrieves a blob from the remote Azure store.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value represnting the key of the blob to retrieve.</param>
        /// <returns>A <see cref="Task{T}"/> based object returning a <see cref="MemoryStream"/> based object.</returns>
        Task<MemoryStream> FindAsync(string key);

        #endregion
    }
}
