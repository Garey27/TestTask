using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerCatalog.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDelete { get; set; }
    }
}