using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Models
{
    public class DemoDataViewModel
    {
        public int DemoDataId { get; set; }
        public string ObjectName { get; set; }
        public IList<Object> Properties { get; set; }
        public int DemoPropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public int ObjectId { get; set; }
        public Object DemoObject { get; set; }
    }
}
