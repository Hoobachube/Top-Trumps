namespace TopTrumps.Files.Services
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Amazon.Runtime.CredentialManagement;
    using Amazon.S3;
    using Amazon.S3.Transfer;
    using Microsoft.Extensions.Configuration;

    public class AwsS3FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public AwsS3FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> UploadFile(string fileName, Stream fileStream)
        {
            var chain = new CredentialProfileStoreChain();
            if (!chain.TryGetAWSCredentials("top_trumps", out var awsCredentials))
            {
                throw new Exception("AWS CREDENTIALS NOT FOUND");
            }

            var key = $"{Guid.NewGuid()}.{fileName}";
         
            using var client = new AmazonS3Client(awsCredentials);

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = fileStream,
                Key = key,
                BucketName = _configuration["AWS:S3BucketName"],
                CannedACL = S3CannedACL.PublicRead
            };

            var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.UploadAsync(uploadRequest);

            return GetUrl(key);
        }

        private string GetUrl(string key)
        {
            var bucketName = _configuration["AWS:S3BucketName"];
            var region = _configuration["Aws:Region"];
            return $"https://{bucketName}.s3.{region}.amazonaws.com/{key}";
        }
    }
}
