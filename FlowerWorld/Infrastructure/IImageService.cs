using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerWorld.Infrastructure
{
    public interface IImageService
    {
        string GetVirtualPath(string path);
        string GetLargeVirPath(string path);
        string GetSmallVirPath(string path);
        string ResizeImage(HttpPostedFileBase file);
    }
}