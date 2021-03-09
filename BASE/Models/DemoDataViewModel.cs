using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Models
{
    public class DemoDataViewModel
    {
        public int DemoDataObjectId { get; set; }
        public string ObjectName { get; set; }
        public List<DemoDataPropertiesViewModel> Properties { get; set; }

    }
}
