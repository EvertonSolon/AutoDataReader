using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
