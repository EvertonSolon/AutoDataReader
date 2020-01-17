using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Entities
{
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int RecordsPerPage { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}
