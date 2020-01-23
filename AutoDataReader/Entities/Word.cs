using AutoDataReader.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AutoDataReader.Entities
{
    public class Word : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
