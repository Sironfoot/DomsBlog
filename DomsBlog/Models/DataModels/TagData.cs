using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.DataModels
{
    public class TagData
    {
        public TagData(int id, string tagName)
        {
            this.Id = id;
            this.TagName = tagName;
        }

        public int Id { get; private set; }
        public string TagName { get; private set; }
    }
}