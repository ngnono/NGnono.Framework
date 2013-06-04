using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using NGnono.Framework.Tools.ImageTools.Models;

namespace NGnono.Framework.Tools.ImageTools.Test
{
    public class ExampleCore
    {
        #region 飞客头像上传专用

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="key">服务端配置索引名</param>
        /// <param name="fileInfor">文件上传后返回的信息对象</param>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public static FileMessage UploadFile(HttpPostedFileBase postedFile, string key, out FileInfor fileInfor, int userId)
        {

            string useridstr = userId.ToString();

            if (useridstr.Length < 9)
            {
                for (int i = 0; i < (9 - useridstr.Length); i++)
                {
                    useridstr = "0" + useridstr;
                }
            }

            string[] folders = new string[2];
            folders[0] = useridstr.Substring(0, 3);
            folders[1] = useridstr.Substring(3, 3);

            ImageServiceClientProxy client = new ImageServiceClientProxy();
            string fileKey;
            string fileExt;

            fileInfor = new FileInfor();

            FileMessage f = client.GetFileNameByUser(key, postedFile.ContentLength, postedFile.FileName, null, out fileKey, out fileExt, folders);

            if (f == FileMessage.Success)
            {
                try
                {
                    fileInfor.FileName = fileKey;
                    fileInfor.FileSize = postedFile.ContentLength;

                    FileUploadMessage inValue = new FileUploadMessage();
                    inValue.FileName = fileKey;
                    inValue.KeyName = key;
                    inValue.FileExt = fileExt;
                    inValue.SaveOrigin = true;

                    if (postedFile.InputStream.CanRead)
                    {
                        //byte[] content = new byte[postedFile.ContentLength + 1];
                        //postedFile.InputStream.Read(content, 0, postedFile.ContentLength);
                        //inValue.FileData = new MemoryStream(content);
                        inValue.FileData = postedFile.InputStream;
                        client.UploadFile(inValue);
                        inValue.FileData.Close();
                        inValue.FileData.Dispose();
                    }
                    else
                    {
                        return FileMessage.UnknowError;
                    }

                    return FileMessage.Success;
                }
                catch
                {
                    return FileMessage.UnknowError;
                }
            }
            else
            {
                return f;
            }
        }

        /// <summary>
        /// 上传文件并返回缩略图大小
        /// </summary>
        /// <param name="postedFile">上传的文件</param>
        /// <param name="key">服务端配置索引名</param>
        /// <param name="fileInfor">文件上传后返回的信息对象</param>
        /// <param name="thumbnailInfo">缩略图信息</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public static FileMessage UploadFileAndReturnInfo(HttpPostedFileBase postedFile, string key, out FileInfor fileInfor, out ThumbnailInfo thumbnailInfo, int userId)
        {

            string useridstr = userId.ToString();

            if (useridstr.Length < 9)
            {
                for (int i = 0; i < (9 - useridstr.Length); i++)
                {
                    useridstr = "0" + useridstr;
                }
            }

            string[] folders = new string[2];
            folders[0] = useridstr.Substring(0, 3);
            folders[1] = useridstr.Substring(3, 3);

            ImageServiceClientProxy client = new ImageServiceClientProxy();
            string fileKey;
            string fileExt;

            fileInfor = new FileInfor();
            thumbnailInfo = new ThumbnailInfo();

            FileMessage f = client.GetFileNameByUser(key, postedFile.ContentLength, postedFile.FileName, null, out fileKey, out fileExt, folders);

            if (f == FileMessage.Success)
            {
                try
                {
                    fileInfor.FileName = fileKey;
                    fileInfor.FileSize = postedFile.ContentLength;

                    FileUploadMessage inValue = new FileUploadMessage();
                    inValue.FileName = fileKey;
                    inValue.KeyName = key;
                    inValue.FileExt = fileExt;
                    inValue.SaveOrigin = true;

                    if (postedFile.InputStream.CanRead)
                    {
                        //byte[] content = new byte[postedFile.ContentLength + 1];
                        //postedFile.InputStream.Read(content, 0, postedFile.ContentLength);
                        //inValue.FileData = new MemoryStream(content);
                        inValue.FileData = postedFile.InputStream;
                        thumbnailInfo = client.UploadFileAndReturnInfo(inValue);
                        inValue.FileData.Close();
                        inValue.FileData.Dispose();
                    }
                    else
                    {
                        return FileMessage.UnknowError;
                    }

                    return FileMessage.Success;
                }
                catch
                {
                    return FileMessage.UnknowError;
                }
            }
            else
            {
                return f;
            }
        }
        #endregion

        #region 文件上传

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="key">服务端配置索引名</param>
        /// <param name="fileInfor">文件上传后返回的信息对象</param>
        /// <returns></returns>
        public static FileMessage UploadFile(HttpPostedFile postedFile, string key, out FileInfor fileInfor)
        {
            HttpPostedFileBase obj = new HttpPostedFileWrapper(postedFile);

            return UploadFile(obj, key, out fileInfor);
        }

        /// <summary>
        /// 上传文件并返回缩略图大小
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="key">服务端配置索引名</param>
        /// <param name="fileInfor">文件上传后返回的信息对象</param>
        /// <param name="thumbnailInfo">缩略图信息</param>
        /// <returns></returns>
        public static FileMessage UploadFileAndReturnInfo(HttpPostedFile postedFile, string key, out FileInfor fileInfor, out ThumbnailInfo thumbnailInfo)
        {
            HttpPostedFileBase obj = new HttpPostedFileWrapper(postedFile);

            return UploadFileAndReturnInfo(obj, key, out fileInfor, out thumbnailInfo);
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="key">服务端配置索引名</param>
        /// <param name="fileInfor">文件上传后返回的信息对象</param>
        /// <returns></returns>
        public static FileMessage UploadFile(HttpPostedFileBase postedFile, string key, out FileInfor fileInfor)
        {
            ImageServiceClientProxy client = new ImageServiceClientProxy();
            string fileKey;
            string fileExt;
            fileInfor = new FileInfor();


            //TODO： 增加contenttype的读取。
            FileMessage f = client.GetFileName(key, postedFile.ContentLength, postedFile.FileName, out fileKey, out fileExt);

            if (f == FileMessage.Success)
            {
                try
                {
                    fileInfor.FileName = fileKey;
                    fileInfor.FileSize = postedFile.ContentLength;
                    fileInfor.FileExtName = fileExt;
                    FileUploadMessage inValue = new FileUploadMessage();
                    inValue.FileName = fileKey;
                    inValue.KeyName = key;
                    inValue.FileExt = fileExt;
                    inValue.SaveOrigin = true;

                    if (postedFile.InputStream.CanRead)
                    {
                        //byte[] content = new byte[postedFile.ContentLength + 1];
                        //postedFile.InputStream.Read(content, 0, postedFile.ContentLength);
                        //inValue.FileData = new MemoryStream(content);
                        inValue.FileData = postedFile.InputStream;
                        client.UploadFile(inValue);
                        inValue.FileData.Close();
                        inValue.FileData.Dispose();
                    }
                    else
                    {
                        return FileMessage.UnknowError;
                    }

                    return FileMessage.Success;
                }
                catch
                {
                    return FileMessage.UnknowError;
                }
            }
            else
            {
                return f;
            }
        }

        /// <summary>
        /// 上传文件并返回缩略图大小a
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="key">服务端配置索引名</param>
        /// <param name="fileInfor">文件上传后返回的信息对象</param>
        /// <param name="thumbnailInfo">缩略图信息</param>
        /// <returns></returns>
        public static FileMessage UploadFileAndReturnInfo(HttpPostedFileBase postedFile, string key, out FileInfor fileInfor, out ThumbnailInfo thumbnailInfo)
        {
            ImageServiceClientProxy client = new ImageServiceClientProxy();
            string fileKey;
            string fileExt;
            fileInfor = new FileInfor();
            thumbnailInfo = new ThumbnailInfo();

            FileMessage f = client.GetFileName(key, postedFile.ContentLength, postedFile.FileName, out fileKey, out fileExt);

            if (f == FileMessage.Success)
            {
                try
                {
                    fileInfor.FileName = fileKey;
                    fileInfor.FileSize = postedFile.ContentLength;
                    fileInfor.FileExtName = fileExt;

                    FileUploadMessage inValue = new FileUploadMessage();
                    inValue.FileName = fileKey;
                    inValue.KeyName = key;
                    inValue.FileExt = fileExt;
                    inValue.SaveOrigin = true;

                    if (postedFile.InputStream.CanRead)
                    {
                        //byte[] content = new byte[postedFile.ContentLength + 1];
                        //postedFile.InputStream.Read(content, 0, postedFile.ContentLength);
                        //inValue.FileData = new MemoryStream(content);
                        inValue.FileData = postedFile.InputStream;
                        thumbnailInfo = client.UploadFileAndReturnInfo(inValue);
                        inValue.FileData.Close();
                        inValue.FileData.Dispose();
                    }
                    else
                    {
                        return FileMessage.UnknowError;
                    }

                    return FileMessage.Success;
                }
                catch
                {
                    return FileMessage.UnknowError;
                }
            }
            else
            {
                return f;
            }
        }

        /// <summary>
        /// 文件集合上传
        /// </summary>
        /// <param name="key">服务端索配置引名</param>
        /// <param name="fileCollection">文件集合</param>
        /// <param name="AutoSize">允许上传的集合大小</param>
        /// <returns></returns>
        public static List<FileInfo> UploadFileCollection(string key, HttpFileCollection fileCollection, int autoSize)
        {
            HttpFileCollectionBase obj = new HttpFileCollectionWrapper(fileCollection);

            return UploadFileCollection(key, fileCollection, autoSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fileCollection"></param>
        /// <param name="autoSize"></param>
        /// <param name="thumbnailInfoes"></param>
        /// <returns></returns>
        public static List<FileInfo> UploadFileCollectionAndReturnInfo(string key, HttpFileCollection fileCollection, int autoSize, out IList<ThumbnailInfo> thumbnailInfoes)
        {
            HttpFileCollectionBase obj = new HttpFileCollectionWrapper(fileCollection);

            return UploadFileCollectionAndReturnInfo(key, fileCollection, autoSize, out thumbnailInfoes);
        }

        /// <summary>
        /// 文件集合上传
        /// </summary>
        /// <param name="key">服务端索配置引名</param>
        /// <param name="fileCollection">文件集合</param>
        /// <param name="AutoSize">允许上传的集合大小</param>
        /// <returns></returns>
        public static List<FileInfor> UploadFileCollection(string key, HttpFileCollectionBase fileCollection, int autoSize)
        {
            // TODO: AutoSize应使用Camel命名法

            List<FileInfor> fileList = new List<FileInfor>();

            for (int i = 0; i < fileCollection.Count; i++)
            {
                if (fileCollection[i].FileName.Length < 5)
                    continue;
                if (fileCollection[i].ContentLength > autoSize)
                {
                    continue;
                }

                FileInfor fileInfor;
                var f = UploadFile(fileCollection[i], key, out fileInfor);

                if (f == FileMessage.Success)
                {
                    autoSize -= fileCollection[i].ContentLength;
                    fileList.Add(fileInfor);
                }
            }
            return fileList;
        }

        /// <summary>
        /// 批量文件上传并返回缩略图信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fileCollection"></param>
        /// <param name="autoSize"></param>
        /// <param name="thumbnailInfoes"></param>
        /// <returns></returns>
        public static List<FileInfor> UploadFileCollectionAndReturnInfo(string key, HttpFileCollectionBase fileCollection, int autoSize, out IList<ThumbnailInfo> thumbnailInfoes)
        {
            // TODO: AutoSize应使用Camel命名法

            List<FileInfor> fileList = new List<FileInfor>();
            thumbnailInfoes = new List<ThumbnailInfo>();

            for (int i = 0; i < fileCollection.Count; i++)
            {
                if (fileCollection[i].FileName.Length < 5)
                {
                    continue;
                }
                if (fileCollection[i].ContentLength > autoSize)
                {
                    continue;
                }

                FileInfor fileInfor;
                ThumbnailInfo info;
                var f = UploadFileAndReturnInfo(fileCollection[i], key, out fileInfor, out info);
                if (f == FileMessage.Success)
                {
                    autoSize -= fileCollection[i].ContentLength;
                    fileList.Add(fileInfor);
                    thumbnailInfoes.Add(info);
                }
            }
            return fileList;
        }

        #endregion

        #region 文件删除

        /// <summary>
        /// 通用的删除文件方法（删除所有规格的文件）
        /// </summary>
        /// <remarks>
        /// 删除前先备份
        /// </remarks>
        /// <example>
        /// GeneralDeleteFile(@"Feike\20091230\7a2bb63b-cc1b-419a-b0d0-ff2bd8b6fbea")
        /// </example>
        /// <param name="filePath">文件完整的相对路径</param>
        /// <returns>是否删除成功</returns>
        public static bool GeneralDeleteFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return false;
            }

            ImageServiceClientProxy client = new ImageServiceClientProxy();

            return client.DeleteNormalFile(new string[] { filePath });
        }

        /// <summary>
        /// 批量的通用的删除文件方法（删除所有规格的文件）
        /// </summary>
        /// <remarks>
        /// 删除前先备份
        /// </remarks>
        /// <example>
        /// GeneralDeleteFile(new string[] { @"Feike\20091230\7a2bb63b-cc1b-419a-b0d0-ff2bd8b6fbea")});
        /// </example>
        /// <param name="filePaths">文件完整的相对路径</param>
        /// <returns>是否删除成功</returns>
        public static bool GeneralDeleteFile(string[] filePaths)
        {
            if (filePaths == null || filePaths.Length < 1)
            {
                return false;
            }

            ImageServiceClientProxy client = new ImageServiceClientProxy();

            return client.DeleteNormalFile(filePaths);
        }

        /// <summary>
        /// 删除文件（删除所有规格的文件）
        /// </summary>
        /// <remarks>
        /// 删除前先备份
        /// 如果是按时间为目录存储的，则是删除当天的文件
        /// </remarks>
        /// <example>
        /// DeleteFile("GroupPortrait", "5cb47724-9f52-4ad0-8098-5877bdd4f278")
        /// </example>
        /// <param name="key">配置文件Key</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static bool DeleteFile(string key, string fileName)
        {
            return DeleteFile(key, new string[] { fileName }, null, null);
        }

        /// <summary>
        /// 删除某天的文件（删除所有规格的文件）
        /// </summary>
        /// <remarks>
        /// 删除前先备份
        /// </remarks>
        /// <example>
        /// DeleteFile("GroupPortrait", "5cb47724-9f52-4ad0-8098-5877bdd4f278",new string[]{"2009","12","30"})
        /// </example>
        /// <param name="key">配置文件Key</param>
        /// <param name="fileName">文件名</param>
        /// <param name="date">日期，格式为new string[]{"2009","12","30"}</param>
        /// <returns></returns>
        public static bool DeleteFile(string key, string fileName, string date)
        {
            return DeleteFile(key, fileName, date, null);
        }

        /// <summary>
        /// 删除文件（删除所有规格的文件）
        /// </summary>
        /// <remarks>
        /// 删除前先备份
        /// </remarks>
        /// <example>
        /// DeleteFile("UserPortrait", "5cb47724-9f52-4ad0-8098-5877bdd4f278","20091020",new string[]{"101","212"});
        /// </example>
        /// <param name="key">配置文件Key</param>
        /// <param name="fileName">文件名</param>
        /// <param name="dateList">日期，格式为"20091020"</param>
        /// <param name="userFolders">自定义的文件夹名,如：new string[]{"101","202"}</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteFile(string key, string fileName, string date, string[] userFolders)
        {
            return DeleteFile(key, new string[] { fileName }, new string[] { date }, userFolders);
        }

        /// <summary>
        /// 批量删除文件（删除所有规格的文件）
        /// </summary>
        /// <remarks>
        /// 删除前先备份
        /// </remarks>
        /// <example>
        /// DeleteFile("GroupPortrait", new string[] {"5cb47724-9f52-4ad0-8098-5877bdd4f278",""8cby7724-9f52-4ad0-8098-5877bdd4ed78");
        /// </example>
        /// <param name="key">配置文件Key</param>
        /// <param name="fileNameList">文件名列表</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteFile(string key, string[] fileNameList)
        {
            return DeleteFile(key, fileNameList, null, null);
        }

        /// <summary>
        /// 批量删除文件（删除所有规格的文件）
        /// </summary>
        /// <remarks>
        /// 删除前先备份
        /// </remarks>
        /// <example>
        /// DeleteFile("UserPortrait", new string[] {"5cb47724-9f52-4ad0-8098-5877bdd4f278",""8cby7724-9f52-4ad0-8098-5877bdd4ed78",new string[]{"101","212"});
        /// </example>
        /// <param name="key">配置文件Key</param>
        /// <param name="fileNameList">文件名列表</param>
        /// <param name="dateList">日期列表,如new string[]{"20091010","20091020"}</param>
        /// <param name="userFolders">自定义的文件夹名</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteFile(string key, string[] fileNameList, string[] dateList, string[] userFolders)
        {
            if (string.IsNullOrEmpty(key) || fileNameList == null || fileNameList.Length == 0)
            {
                return false;
            }

            ImageServiceClientProxy client = new ImageServiceClientProxy();

            return client.DeleteFile(key, fileNameList, dateList, userFolders);
        }

        #endregion

        #region MetaWeblog 上传图片接口

        /// <summary>
        /// 上传文件并返回缩略图大小
        /// </summary>
        /// <param name="postedFile">上传的文件对象</param>
        /// <param name="key">服务端配置索引名</param>
        /// <param name="fileInfor">文件上传后返回的信息对象</param>
        /// <param name="thumbnailInfo">缩略图信息</param>
        /// <returns></returns>
        public static FileMessage UploadFileAndReturnInfo(string key, Stream inputStream, int contentLength, string fileName, out FileInfor fileInfor, out ThumbnailInfo thumbnailInfo)
        {
            ImageServiceClientProxy client = new ImageServiceClientProxy();
            string fileKey;
            string fileExt;
            fileInfor = new FileInfor();
            thumbnailInfo = new ThumbnailInfo();

            FileMessage f = client.GetFileName(key, contentLength, fileName, out fileKey, out fileExt);

            if (f == FileMessage.Success)
            {
                try
                {
                    fileInfor.FileName = fileKey;
                    fileInfor.FileSize = contentLength;

                    FileUploadMessage inValue = new FileUploadMessage();
                    inValue.FileName = fileKey;
                    inValue.KeyName = key;
                    inValue.FileExt = fileExt;
                    inValue.SaveOrigin = true;

                    if (inputStream.CanRead)
                    {
                        inValue.FileData = inputStream;
                        thumbnailInfo = client.UploadFileAndReturnInfo(inValue);
                        inValue.FileData.Close();
                        inValue.FileData.Dispose();
                    }
                    else
                    {
                        return FileMessage.UnknowError;
                    }

                    return FileMessage.Success;
                }
                catch
                {
                    return FileMessage.UnknowError;
                }
            }
            else
            {
                return f;
            }
        }

        /// <summary>
        /// 上传文件并返回缩略图大小( base64string )
        /// </summary>
        /// <param name="key"></param>
        /// <param name="inputBase64String"></param>
        /// <param name="contentLength"></param>
        /// <param name="fileName"></param>
        /// <param name="fileInfor"></param>
        /// <param name="thumbnailInfo"></param>
        /// <returns></returns>
        public static FileMessage UploadFileAndReturnInfo(string key, string inputBase64String, int contentLength, string fileName, out FileInfor fileInfor, out ThumbnailInfo thumbnailInfo)
        {
            char[] charBuffer = inputBase64String.ToCharArray();
            byte[] bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length);

            using (var str = new MemoryStream(bytes))
            {
                return UploadFileAndReturnInfo(key, str, contentLength, fileName, out fileInfor, out thumbnailInfo);
            }
        }

        #endregion

        #region 网络图片

        /// <summary>
        /// 抓取网络图片
        /// </summary>
        /// <param name="key">服务端配置索引名</param>
        /// <param name="originalImageUrl">原图片的Url</param>
        /// <param name="fileInfor">文件上传后返回的信息对象</param>
        /// <param name="thumbnailInfo">缩略图信息</param>
        /// <returns></returns>
        public static FileMessage SaveWebImage(string key, string originalImageUrl, out FileInfor fileInfor, out ThumbnailInfo thumbnailInfo)
        {
            var req = WebRequest.Create(originalImageUrl);
            var resp = req.GetResponse();

            using (var stream = resp.GetResponseStream())
            {
                //var imageFileName = originalImageUrl.Substring(originalImageUrl.LastIndexOf("/") + 1) + ".jpg";

                //Note:参数fileName仅用于截取扩展名后判断“是否允许上传该类型图片”，硬编码为“image.jpg”以减少不必要的字符串操作
                return UploadFileAndReturnInfo(key, stream, (int)resp.ContentLength, "image.jpg", out fileInfor, out thumbnailInfo);
            }
        }


        #endregion
    }
}
