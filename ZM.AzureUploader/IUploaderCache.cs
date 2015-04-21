namespace ZM.AzureUploader
{
    using System.Threading.Tasks;
    using ZM.AzureUploader.Models;

    /// <summary>
    /// Defines the structure required of any object providing file caching services to the application.
    /// </summary>
    public interface IUploaderCache
    {
        #region Methods

        /// <summary>
        /// Adds a given file to the internal caching structure.
        /// </summary>
        /// <param name="file">A <see cref="UploaderFile"/> based object.</param>
        void Add(UploaderFile file);

        /// <summary>
        /// Async method for adding a file to the internal caching structure.
        /// </summary>
        /// <param name="file">A <see cref="UploaderFile"/> based object to be stored.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        Task AddAsync(UploaderFile file);

        /// <summary>
        /// Removes a specific file from the internal caching structure.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value represnting the key of the file to be flushed.</param>
        void Remove(string key);

        /// <summary>
        /// Async method for removing a specific file from the internal caching structure.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value represnting the key of the file to be flushed.</param>
        /// <returns>A <see cref="Task"/> based object.</returns>
        Task RemoveAsync(string key);

        /// <summary>
        /// Flushes the entire caching structure of all saved files.
        /// </summary>
        void Flush();

        /// <summary>
        /// Async method for flushing the entire caching structure of all saved files.
        /// </summary>
        /// <returns>A <see cref="Task"/> based object.</returns>
        Task FlushAsync();

        #endregion
    }
}
