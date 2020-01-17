using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDataReader.Entities
{
    public class PaginationList<T>
    {
        public List<T> Words { get; set; } = new List<T>();

        public Pagination Pagination { get; set; }

        public List<Link> Links { get; set; } = new List<Link>();
    }
}
