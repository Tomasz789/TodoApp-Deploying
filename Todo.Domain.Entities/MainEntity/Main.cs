using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities.MainEntity
{
    public class Main
    {
        public Main()
        {
            this.CreatedDate = DateTime.Now;
            this.Updated = DateTime.Now;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime Updated { get; set; }


    }
}
