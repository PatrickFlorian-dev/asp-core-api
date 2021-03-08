using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    class DemoDataProperties
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }

        public int ObjectId { get; set; }
        public DemoDataObject DemoObject { get; set; }
    }
}
