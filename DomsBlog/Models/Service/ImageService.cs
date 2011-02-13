using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.ViewModels;
using DomsBlog.Models.NHibernate.Domain;
using DomsBlog.Models.Repositories;

namespace DomsBlog.Models.Service
{
    public class ImageService : IImageService
    {
        private IBlogRepository BlogRepository = null;

        public ImageService()
        {
            BlogRepository = RepositoryFactory.GetBlogRepository();
        }

        public RandomImageView GetRandomImage()
        {
            RandomImageView imageView = null;

            Image image = BlogRepository.GetRandomImage();

            if (image != null)
            {
                Blog blog = image.Blog;

                imageView = new RandomImageView(image.Id, image.AltText, image.Caption, image.FileName, blog.Id, blog.Title);
            }

            return imageView;
        }

        public ImageView GetImageFromId(int imageId)
        {
            Image image = BlogRepository.GetImageFromId(imageId);

            if (image != null)
            {
                return new ImageView(image.Id, image.AltText, image.Caption, image.FileName);
            }

            return null;
        }
    }
}