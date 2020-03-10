using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService1.Models.Weathers
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
    }
}
