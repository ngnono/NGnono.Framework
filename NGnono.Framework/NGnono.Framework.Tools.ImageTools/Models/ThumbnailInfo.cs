using System.Collections.Generic;
using System.ServiceModel;

namespace NGnono.Framework.Tools.ImageTools.Models
{
    /// <summary>
    /// 缩率图信息
    /// </summary>
    [MessageContract]
    public class ThumbnailInfo
    {
        /// <summary>
        /// 缩略图文件大小
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public IDictionary<string, long> Info;

        /// <summary>
        /// Exif信息
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public IDictionary<int, string> ExifInfos;

        /// <summary>
        /// 缩略图尺寸
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public IDictionary<string, ImageSize> Sizes;
    }

    /// <summary>
    /// 尺寸
    /// </summary>
    [MessageContract]
    public class ImageSize
    {
        /// <summary>
        /// 宽y
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public int Width;

        /// <summary>
        /// 高
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public int Height;

        public ImageSize(int w, int h)
        {
            Width = w;
            Height = h;
        }
    }
}
