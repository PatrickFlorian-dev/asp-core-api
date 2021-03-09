using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    class DemoDataObject
    {
        public int Id { get; set; }
        public string ObjectName { get; set; }
        public IList<DemoDataProperties> Properties { get; set; }

    }
}
