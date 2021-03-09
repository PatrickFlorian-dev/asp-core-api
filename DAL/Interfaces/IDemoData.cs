using BASE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.DemoDataLogic
{
    public interface IDemoData
    {
        DemoDataViewModel GetDemoObjectWithProperties(int id);
        List<DemoDataViewModel> GetAllDemoDataObjects();
        DemoDataViewModel AddDemoObject(DemoDataViewModel demoObject);

        DemoDataPropertiesViewModel AddDemoProperties(DemoDataPropertiesViewModel demoPropsObject);
    }
}
