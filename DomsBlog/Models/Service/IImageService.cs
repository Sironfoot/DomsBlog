using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.ViewModels;

namespace DomsBlog.Models.Service
{
    public interface IImageService
    {
        RandomImageView GetRandomImage();
        ImageView GetImageFromId(int imageId);
    }
}