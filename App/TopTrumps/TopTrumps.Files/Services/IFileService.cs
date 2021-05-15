namespace TopTrumps.Files.Services
{
    using System.IO;
    using System.Threading.Tasks;

    public interface IFileService
    {
        Task<string> UploadFile(string fileName, Stream fileStream);
    }
}
