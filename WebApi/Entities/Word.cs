using System.ComponentModel.DataAnnotations;
using WebApi.Entities.Base;

namespace WebApi.Entities
{
    public class Word : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
