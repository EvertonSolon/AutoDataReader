using AutoDataReader.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDataReader.Entities
{
    class WordDto : Word
    {
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
