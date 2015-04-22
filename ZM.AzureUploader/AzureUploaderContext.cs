namespace ZM.AzureUploader
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ZM.AzureUploader.Models;

    /// <summary>
    /// Class representing a unit of work-esc context over the Azure Uploader storage structure.
    /// </summary>
    public class AzureUploaderContext : IUploaderContext
    {
        #region Fields

        private readonly IBlobSource blobSource;
        private readonly IMetadataSource metadataSource;

        private readonly List<UploaderFile> toUpload = new List<UploaderFile>(); // not multi-thread.  need to update this or handle multithreaded situations.
        private volatile bool isUploading;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="AzureUploaderContext"/> class, requiring runtime settings to be provided.
        /// </summary>
        /// <param name="settings">An <see cref="IUploadSettings"/> </param>
        public AzureUploaderContext(IBlobSource blobSource, IMetadataSource metadataSource)
        {
            if (blobSource == null)
                throw new ArgumentNullException("blobSource");

            if (metadataSource == null)
                throw new ArgumentNullException("metadataSource");

            this.blobSource = blobSource;
            this.metadataSource = metadataSource;
        }

        #endregion

        #region Methods
        #endregion

        #region IUploaderContext members

        /// <summary>
        /// Gets a reference to a value indicating if the context has changed, or has pending changes to be saved to the underlying tier.
        /// </summary>
        public bool IsDirty { get; protected set; }

        /// <summary>
        /// Method capable of searching the indexed blob / metadata for a user specified file.
        /// </summary>
        /// <param name="searchKey">A <see cref="string"/> value representing the search key to use in matching the results.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> based collection of <see cref="UploaderFile"/> based objects.</returns>
        public Task<IEnumerable<UploaderFile>> SearchAsync(string searchKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets a reference to an object representing a blob / file to be stored.
        /// </summary>
        /// <param name="blob"></param>
        /// <returns>An <see cref="UploaderFile"/> representing the file added to the context.</returns>
        public UploaderFile Add(UploaderFile blob)
        {
            this.toUpload.Add(blob);

            this.IsDirty = true;
            return blob;
        }

        /// <summary>
        /// Method called to publish the current units of work to the remote storage containers.
        /// </summary>
        /// <returns>A <see cref="Task"/> based object.</returns>
        public async Task SaveAsync()
        {
            if (!this.IsDirty || this.isUploading)
                return;

            this.isUploading = true;

            foreach(var file in this.toUpload)
            {
                try
                {
                    await this.blobSource.UploadAsync(file.File);
                }
                catch(Exception ex)
                {
                    // catch, notify, and skip.
                    // Should we continue processing?
                }

                // if continue processing and not skip.
                try
                {
                    await this.metadataSource.AddAsync(file.FileMetadata);
                }
                catch(Exception ex)
                {
                    // catch, and rollback.
                    // need to add remove from blob source.
                }
            }

            this.toUpload.Clear();
            this.IsDirty = false;
            this.isUploading = false;
        }

        #endregion
    }
}
