using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Entities
{
    public class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public string Method { get; set; }

        public Link(string rel, string hRef, string method)
        {
            Rel = rel;
            Href = hRef;
            Method = method;
        }
    }
}
