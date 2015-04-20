﻿namespace ZM.AzureUploader
{
    /// <summary>
    /// Defines the structure required of objects representing a the set of settings needed to access and manage the azure storage and files.
    /// </summary>
    public interface IUploadSettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets a reference to a value representing the connection string used to access the Azure Blob storage.
        /// </summary>
        string StorageConnectionString { get; set; }

        #endregion
    }
}
