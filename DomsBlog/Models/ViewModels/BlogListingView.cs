using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.UrlTools;
using MvcLibrary.Extensions;

namespace DomsBlog.Models.ViewModels
{
    public class BlogListingView : BaseView
    {
        public BlogListingView(int currentPage, int recordsPerPage, int totalRecords)
        {
            this.CurrentPage = currentPage;
            this.RecordsPerPage = recordsPerPage;
            this.TotalRecords = totalRecords;
        }

        public int TotalRecords { get; private set; }
        public int RecordsPerPage { get; private set; }
        public int CurrentPage { get; private set; }

        public bool HasNextPage
        {
            get { return (CurrentPage * RecordsPerPage) < TotalRecords; }
        }

        public bool HasPreviousPage
        {
            get { return CurrentPage > 1; }
        }

        private List<BlogItemView> _blogs = new List<BlogItemView>();
        public IList<BlogItemView> Blogs
        {
            get { return _blogs; }
        }

        public class BlogItemView
        {
            public BlogItemView(int id, string title, DateTime datePosted, int numComments,
                int numImages, string blogType, string abstractText)
            {
                this.Id = id;
                this.Title = title;
                this.PostedDate = datePosted.ToString("d MMMM yyyy - h:mm tt");
                this.UrlFriendlyTitle = title.ToFriendlyUrl();
                this.NumComments = numComments;
                this.NumImages = numImages;
                this.BlogType = blogType;
                this.AbstractText = abstractText;
            }

            public int Id { get; private set; }
            public string Title { get; private set; }
            public string UrlFriendlyTitle { get; private set; }
            public string PostedDate { get; private set; }
            public int NumComments { get; private set; }
            public int NumImages { get; private set; }
            public string BlogType { get; private set; }
            public string AbstractText { get; private set; }
            public PreviewImageView PreviewImage { get; set; }

            private List<TagView> _tags = new List<TagView>();
            public IList<TagView> Tags
            {
                get { return _tags; }
            }
        }

        public class TagView
        {
            public TagView(int id, string tagName)
            {
                this.Id = id;
                this.TagName = tagName;
                this.UrlFriendTagName = tagName.ToFriendlyUrl();
            }

            public int Id { get; private set; }
            public string TagName { get; private set; }
            public string UrlFriendTagName { get; private set; }
        }

        public class PreviewImageView
        {
            public PreviewImageView(int imageId, string filename, string caption, string altText)
            {
                this.ImageId = imageId;
                this.Filename = filename;
                this.Caption = caption;
                this.AltText = altText.IsNullEmptyOrWhitespace() ? caption : altText;
            }

            public int ImageId { get; private set; }
            public string Filename { get; private set; }
            public string Caption { get; private set; }
            public string AltText { get; private set; }

            public string FullUrl
            {
                get { return "/Images/" + this.ImageId + "/" + this.Filename; }
            }
            public string ThumbUrl
            {
                get { return "/Images/" + this.ImageId + "/thumb_" + this.Filename; }
            }
        }
    }
}