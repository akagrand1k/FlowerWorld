using ImageResizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace FlowerWorld.Infrastructure
{
    public class ImageService : IImageService
    {
        /// <summary>
        /// Преобразование полного физического пути в виртуальный
        /// </summary>
        /// <param name="PhysicalPath"></param>
        /// <returns>string virtual path</returns>
        public string GetVirtualPath(string path)
        {
            string _str = @"Content\Images\ProductImage";
            path = path.Substring(path.LastIndexOf(_str));
            path = path.Replace(@"\", @"/");
            path = "~/" + path;
            return path;
        }

        /// <summary>
        /// Получает путь картинки с измененным  разрешением.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetLargeVirPath(string path)
        {
            path = path.Insert(path.LastIndexOf("."), "l");
            return GetVirtualPath(path); ;
        }

        /// <summary>
        /// Получает путь картинки с разрешением
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetSmallVirPath(string path)
        {
            path = path.Insert(path.LastIndexOf("."), "s");
            return GetVirtualPath(path);
        }
        public string ResizeImage(HttpPostedFileBase file)
        {
            var _fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var pathDb = HttpContext.Current.Server.MapPath("~/Content/Images/ProductImage/" + _fileName);
            var pathStock  = HttpContext.Current.Server.MapPath("~/Content/Images/ProductImage/");
            if (file != null)
            {
                var ext = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);
                
                var versions = new Dictionary<string, string>();
                versions.Add("s", "maxwidth=50&maxheight=50&format=" + "jpg");
                versions.Add("l", "maxwidth=200&maxheight=200&format=" + "jpg");

                foreach (var suffix in versions.Keys)
                {
                    file.InputStream.Seek(0, System.IO.SeekOrigin.Begin);

                    ImageBuilder.Current.Build(
                        new ImageJob(
                            file.InputStream,
                            pathStock + _fileName.Remove(_fileName.LastIndexOf(".")) + suffix,
                            new Instructions(versions[suffix]),
                            false,
                            true));
                }
            }
            return pathDb;
        }
    }
}