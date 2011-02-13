using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcLibrary.BBCode
{
    public interface IParser
    {
        string ParseBeforeLineBreaksEncoding(string bbCode);
        string ParseAfterLineBreaksEncoding(string bbCode);
    }
}