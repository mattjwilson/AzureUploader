namespace ZM.AzureUploader
{
    /// <summary>
    /// Defines the structure required of objects representing a the set of settings needed to access and manage the azure storage and files.
    /// </summary>
    public interface IUploadSettings
    {
        #region Properties

        /// <summary>
        /// Gets a reference to a value representing the connection string used to access the Azure Blob storage.
        /// </summary>
        string BlobConnectionString { get; }

        /// <summary>
        /// Gets a reference to a value representing the connection string used to access the Azure Blob storage.
        /// </summary>
        string MetadataConnectionString { get; }

        /// <summary>
        /// Gets a reference to a value representing the name of the container the blobs are stored in.
        /// </summary>
        string BlobContainerName { get; }

        #endregion
    }
}
