using BASE.Models;
using DAL.DataContext;
using LOGIC.DemoDataLogic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.Entities;

namespace DAL.Functions
{
    public class DemoDataFunctions : IDemoData
    {
        private DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.dbOptions);

        public DemoDataFunctions()
        {
            
        }

        // Get A Demo Data Object and it's properties By It's ID
        public DemoDataViewModel GetDemoObjectWithProperties(int id)
        {

            DemoDataViewModel demoDataModel = dbContext.DemoDataObject
                .Where( d => d.Id == id )
                .Select(d =>
                    new DemoDataViewModel
                    {
                        DemoDataObjectId = d.Id,
                        ObjectName = d.ObjectName,
                        Properties = dbContext.DemoDataProperties.Where(props => props.ObjectId == d.Id).Select(p => new DemoDataPropertiesViewModel
                        {
                            Id = p.Id,
                            PropertyName = p.PropertyName,
                            PropertyDescription = p.PropertyDescription
                        }).ToList()
                    })
                .SingleOrDefault();

            return demoDataModel;

        }

        // Get the list of demo data models
        public List<DemoDataViewModel> GetAllDemoDataObjects()
        {
            List<DemoDataViewModel> demoDataModel = dbContext.DemoDataObject.Select(d => new DemoDataViewModel {
                DemoDataObjectId = d.Id,
                ObjectName = d.ObjectName,
                Properties = dbContext.DemoDataProperties.Where(props => props.ObjectId == d.Id).Select(p => new DemoDataPropertiesViewModel
                {
                    Id = p.Id,
                    PropertyName = p.PropertyName,
                    PropertyDescription = p.PropertyDescription
                }).ToList()
            } ).ToList();

            return demoDataModel;
        }

        // Insert a new Demo Object 
        public DemoDataViewModel AddDemoObject(DemoDataViewModel demoObject)
        {

            DemoDataObject newDemoObj = new DemoDataObject
            {
                ObjectName = demoObject.ObjectName
            };

            dbContext.DemoDataObject.Add(newDemoObj);
            dbContext.SaveChanges();

            DemoDataViewModel returnDemoObj = new DemoDataViewModel
            {
                DemoDataObjectId = newDemoObj.Id,
                ObjectName = newDemoObj.ObjectName,
                Properties = null
            };

            return returnDemoObj;
        }

        // Insert a new Demo Property
        public DemoDataPropertiesViewModel AddDemoProperties(DemoDataPropertiesViewModel demoPropsObject)
        {
            DemoDataProperties newDemoPropsObj = new DemoDataProperties
            {
                ObjectId = demoPropsObject.ObjectId,
                PropertyName = demoPropsObject.PropertyName,
                PropertyDescription = demoPropsObject.PropertyDescription
            };

            dbContext.DemoDataProperties.Add(newDemoPropsObj);
            dbContext.SaveChanges();

            DemoDataPropertiesViewModel returnDemoObj = new DemoDataPropertiesViewModel
            {
                Id = newDemoPropsObj.Id,
                ObjectId = newDemoPropsObj.ObjectId,
                PropertyName = newDemoPropsObj.PropertyName,
                PropertyDescription = newDemoPropsObj.PropertyDescription
            };

            return returnDemoObj;
        }

    }
}
