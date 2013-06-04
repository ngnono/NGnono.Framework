using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using NGnono.Framework.Logger;

namespace NGnono.Framework.Tools.ImageTools.Test
{
    public class Test
    {
        private ILog Logger = LoggerManager.Current();
        private readonly string _convertPath = ConfigurationManager.AppSettings["convertFilePath"];

        private static Test _instance = new Test();

        private Test()
        {
        }

        public static Test Current
        {
            get { return _instance; }
        }

        public void Run()
        {
            //ImageMagickNET.MagickNet.InitializeMagick();
            string input = System.IO.Path.GetFullPath(@"E:\web\hangzhouV45\fileupload\img\product\20130114\b3f01d9d-4e6b-4414-a970-774b9339f76d_original.jpg");
            int[] widths = new int[] { 120, 240, 640 };
            foreach (var width in widths)
            {
                MakeThumbnailPicAndReturnSize(input, System.IO.Path.GetFullPath(String.Format(@"E:\web\hangzhouV45\fileupload\img\product\20130114\4ad83071-e5f7-4d12-afa7-bb79d20a014d_{0}.jpg", width)), width, 0);
            }
        }
        public void MakeThumbnailPicAndReturnSize(string originalImagePath, string thumbnailPath, int width, int height)
        {
            StringBuilder sbFileArgs = new StringBuilder()
                        .Append(String.Format("{0}", originalImagePath))
                //  .Append(@" -intent relative")
                       .AppendFormat(@"  -resize {0}x ", width)
                //         .Append(@" -unsharp .5x.5+.5+0 ")
                //        .Append(@" -depth 8 ")
                //     .Append(@" -strip")
                //        .Append(@" -quality 100 ");
                        .Append(thumbnailPath);
            string fileArgs = sbFileArgs.ToString();
            Logger.Debug(fileArgs);
            CallImageMagick(fileArgs);
            /*
           ImageMagickNET.Image tempImage = new ImageMagickNET.Image();
           tempImage.Read(originalImagePath);
           Geometry geo = new Geometry();
           geo.Width((uint)width);
           geo.Aspect();
           tempImage.Resize(geo);
           tempImage.Unsharpmask(1.5, 1, 0.7, 0.02);   //must keep value like this
           tempImage.Write(thumbnailPath);
           return;
             * */
        }
        //public static void MakeThumbnailPicAndReturnSize2(string originalImagePath, string thumbnailPath, int width, int height)
        //{
        //    Geometry geo = new Geometry();
        //    geo.Width((uint)width);

        //    geo.Aspect();
        //    ImageMagickNET.Image tempImage = new ImageMagickNET.Image(originalImagePath);
        //    tempImage.Resize(geo);
        //    tempImage.Quality(80);
        //    tempImage.Write(thumbnailPath);
        //    return;

        //}

        private void CallImageMagick(string fileArgs)
        {
            var startInfo = new ProcessStartInfo
            {
                Arguments = fileArgs,
                FileName = System.IO.Path.GetFullPath(_convertPath),
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardOutput = true
            };

            try
            {
                using (var exeProcess = Process.Start(startInfo))//Process.Start(System.IO.Path.Combine(pathImageMagick,appImageMagick),fileArgs))
                {

                    exeProcess.WaitForExit();
                    exeProcess.Close();
                }

            }
            catch
            {

                throw;
            }

        }
    }
}
