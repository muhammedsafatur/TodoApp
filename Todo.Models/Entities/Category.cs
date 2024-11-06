using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Category : Entity<int>
    {
        // required yerine [Required] veri anotasyonu kullanın
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public List<Todo> Todos { get; set; }

        // Parametresiz yapıcı ekleyin
        public Category()
        {
            Todos = new List<Todo>();
        }
    }
}
