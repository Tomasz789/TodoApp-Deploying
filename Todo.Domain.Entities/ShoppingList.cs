using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Todo.Domain.Entities.MainEntity;

namespace Todo.Domain.Entities
{
    public class ShoppingList : Main
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DueDate { get; set; }

        public Guid UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
