using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace TodoApp.Interop.Services.DatasheetServices
{
    public abstract class DatasheetBaseService<T> where T : class
    {
        protected Application app;

        public DatasheetBaseService()
        {
            app = new Application();
        }

        public abstract string InfoMsg { get; }

        public bool AppVisible { get; set; } = true;

        public abstract int GenerateXslxFile(T entity);

        protected abstract void ReleaseAppObject(object objectToRelease);
    }
}
