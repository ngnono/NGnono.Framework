using NGnono.Framework.Tools.ImageTools.Client;
using NGnono.Framework.Tools.ImageTools.Contract;
using NGnono.Framework.Tools.ImageTools.Models;

namespace NGnono.Framework.Tools.ImageTools.Test
{
    public class ImageServiceClientProxy : IImageService
    {
        private readonly IImageService _imageService;//new ImageService();
        private const string ImageServiceEndpointName = "ImageServiceEndpoint";


        public ImageServiceClientProxy()
            : this(new ImageServiceClient(ImageServiceEndpointName))
        {
        }

        public ImageServiceClientProxy(IImageService imageService)
        {
            _imageService = imageService;
        }

        public void UploadFile(FileUploadMessage request)
        {
            _imageService.UploadFile(request);
        }

        public ThumbnailInfo UploadFileAndReturnInfo(FileUploadMessage request)
        {
            return _imageService.UploadFileAndReturnInfo(request);
        }

        public FileMessage GetFileName(string key, int fileSize, string clientFilePath, out string fileKey, out string fileExt)
        {
            return _imageService.GetFileName(key, fileSize, clientFilePath, out fileKey, out fileExt);
        }

        public FileMessage GetFileName(string key, int fileSize, string clientFilePath, string contentType, out string fileKey,
                                       out string fileExt)
        {
            return _imageService.GetFileName(key, fileSize, clientFilePath, contentType, out fileKey, out fileExt);
        }

        public FileMessage GetFileNameByUser(string key, int fileSize, string clientFilePath, string contentType, out string fileKey, out string fileExt,
                                             string[] userFolders)
        {
            return _imageService.GetFileNameByUser(key, fileSize, clientFilePath, contentType, out fileKey, out fileExt,
                                                   userFolders);
        }

        public bool IsExistingFile(string key, string fileName, string fileExt)
        {
            return
                _imageService.IsExistingFile(key, fileName, fileExt);
        }

        public bool HandleGroupPortrait(string fileName, string url)
        {
            return _imageService.HandleGroupPortrait(fileName, url);
        }

        public bool DeleteFile(string key, string[] fileNameList, string[] date, string[] userFolders)
        {
            return _imageService.DeleteFile(key, fileNameList, date, userFolders);
        }

        public bool DeleteNormalFile(string[] filePaths)
        {
            return _imageService.DeleteNormalFile(filePaths);
        }
    }
}