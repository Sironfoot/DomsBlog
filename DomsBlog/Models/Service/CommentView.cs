using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.Service
{
    public class CommentView
    {
        public int Id { get; set; }
        public string Title { get; set; }

        private string _commentText = "";
        public string CommentText
        {
            get { return _commentText; }
            set { _commentText = value; }
        }


        public string Author { get; set; }
        public string Website { get; set; }
        public DateTime PostedDate { get; set; }

        public CommentView ParentComment { get; set; }
        public IList<CommentView> ChildComments { get; set; }

        public bool AdminComment { get; set; }

        public bool HighlightMe { get; set; }
    }
}