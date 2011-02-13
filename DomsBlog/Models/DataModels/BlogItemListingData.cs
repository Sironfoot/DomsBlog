using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.NHibernate.Domain;

namespace DomsBlog.Models.DataModels
{
    public class BlogItemListingData
    {
        public BlogItemListingData(int id, string title, string blogType, string abstractText,
            DateTime postedDate, int numComments, int numImages)
        {
            this.Id = id;
            this.Title = title;
            this.BlogType = blogType;
            this.AbstractText = abstractText;
            this.PostedDate = postedDate;
            this.NumComments = numComments;
            this.NumImages = numImages;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string BlogType { get; private set; }
        public string AbstractText { get; private set; }
        public DateTime PostedDate { get; private set; }
        public int NumComments { get; private set; }
        public int NumImages { get; private set; }

        private List<TagData> _tags = new List<TagData>();
        public IList<TagData> Tags
        {
            get { return _tags; }
        }

        public Image PreviewImage { get; set; }
    }
}