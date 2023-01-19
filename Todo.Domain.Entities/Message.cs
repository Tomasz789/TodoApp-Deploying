using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Todo.Domain.Entities.ReportTypes;

namespace Todo.Domain.Entities
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ReportType ReportType { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
