using BASE.Models;
using DAL.Functions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.DemoDataLogic
{
    public class DemoDataLogic
    {
        private IDemoData _demoFunctions = new DemoDataFunctions();

        private HttpResult httpResult = new HttpResult();

        public HttpResult GetDemoObjectWithProperties(int id)
        {
            try
            {
                DemoDataViewModel result = _demoFunctions.GetDemoObjectWithProperties(id);
                if (result != null)
                {
                    httpResult.success = true;
                    httpResult.data = result;
                    httpResult.message = "Succesfully retrieved Demo Object With Properties";
                    return httpResult;
                }
                else
                {
                    httpResult.success = false;
                    httpResult.data = result;
                    httpResult.message = "Failed to retrieve Demo Object With Propertiess";
                    return httpResult;
                }
            }
            catch (Exception error)
            {
                return new HttpResult { success = false, data = error, message = "API failed - GetDemoObjectWithProperties" };
            }
        }

        public HttpResult GetDemoObjects()
        {
            try
            {
                List<DemoDataViewModel> result = _demoFunctions.GetAllDemoDataObjects();
                if (result != null)
                {
                    httpResult.success = true;
                    httpResult.data = result;
                    httpResult.message = "Succesfully retrieved Demo Objects";
                    return httpResult;
                }
                else
                {
                    httpResult.success = false;
                    httpResult.data = result;
                    httpResult.message = "Failed to retrieve Demo Objects";
                    return httpResult;
                }
            }
            catch (Exception error)
            {
                return new HttpResult { success = false, data = error, message = "API failed - GetDemoObjectWithProperties" };
            }
        }

        public HttpResult AddDemoObject(DemoDataViewModel demoObject)
        {
            try
            {
                DemoDataViewModel result = _demoFunctions.AddDemoObject(demoObject);
                if (result != null)
                {
                    httpResult.success = true;
                    httpResult.data = result;
                    httpResult.message = "Succesfully added Demo Objects";
                    return httpResult;
                }
                else
                {
                    httpResult.success = false;
                    httpResult.data = result;
                    httpResult.message = "Failed to add Demo Objects";
                    return httpResult;
                }
            }
            catch (Exception error)
            {
                return new HttpResult { success = false, data = error, message = "API failed - AddDemoObject" };
            }
        }

        public HttpResult AddDemoProperties(DemoDataPropertiesViewModel demoPropsObject)
        {
            try
            {
                DemoDataPropertiesViewModel result = _demoFunctions.AddDemoProperties(demoPropsObject);
                if (result != null)
                {
                    httpResult.success = true;
                    httpResult.data = result;
                    httpResult.message = "Succesfully added Demo Property";
                    return httpResult;
                }
                else
                {
                    httpResult.success = false;
                    httpResult.data = result;
                    httpResult.message = "Failed to add Demo Property";
                    return httpResult;
                }
            }
            catch (Exception error)
            {
                return new HttpResult { success = false, data = error, message = "API failed - AddDemoProperties" };
            }
        }

    }
}
