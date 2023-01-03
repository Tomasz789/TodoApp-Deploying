using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities
{
    public class Notify
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsRead { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid UserId { get; set; }

        public AppUser User { get; set; }
    }
}
