using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class CardLists
    {
        public int Id { get; set; }
        [Required]
        public string CardName { get; set; }

        public string Description { get; set; }
        public bool Active { get; set; }

    }
}
