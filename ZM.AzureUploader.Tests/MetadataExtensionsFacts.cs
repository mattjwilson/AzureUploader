namespace ZM.AzureUploader.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using Xunit;
    using ZM.AzureUploader.Models;

    public class MetadataExtensionsFacts
    {
        #region Methods

        [Fact(DisplayName = "")]
        public void ToStorageMetadataShouldTranslateAllProperties()
        {
            var date = DateTime.UtcNow;
            var dateTwo = DateTime.UtcNow;

            var target = new Metadata
            {
                CreatedDate = date,
                Description = "test description",
                FileName = "file.txt",
                IsPrivate = true,
                ModifiedByKey = "123456",
                ModifiedDate = dateTwo,
                SharedKey = "0988776",
                UploaderKey = "123458"
            };

            
        }

        #endregion
    }
}
