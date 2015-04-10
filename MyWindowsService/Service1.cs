using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsService
{
    public partial class MyService : ServiceBase
    {
        public MyService()
        {
            Debugger.Launch();
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            IEnumerable<Entity1> items = null;
            using (var db = new MyProjectModelContainer())
            {
                // Create and save a new entity 
                var entity1 = new Entity1();
                db.Entity1.Add(entity1);
                db.SaveChanges();

                // Display all entities from the database 
                var query = from b in db.Entity1
                            orderby b.Id
                            select b;

                items = query.ToList();
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\temp\\myService.txt"))
            {
                foreach (var item in items)
                {
                    file.WriteLine(item.Id);
                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
