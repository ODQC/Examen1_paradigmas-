using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickNotes.Data
{
    
        public static class DbInitializer
        {
            public static void Initialize(DataContext context)
            {
                context.Database.EnsureCreated();

                // Look for any Usuarios.
                if (context.Usuarios.Any())
                {
                    return;   // DB has been seeded
                }

                //var Usuarios = new Student[]
                //{
           
                //};
                //foreach (Usuario s in Usuarios)
                //{
                //    context.Usuarios.Add(s);
                //}
                //context.SaveChanges();

                //var courses = new Course[]
                //{
            
                //};
                //foreach (Course c in courses)
                //{
                //    context.Courses.Add(c);
                //}
                //context.SaveChanges();

                //var Cuadernos = new Cuaderno[]
                //{
            
                //};
                //foreach (Cuaderno e in Cuadernos)
                //{
                //    context.Enrollments.Add(e);
                //}
                //context.SaveChanges();
            }
        }
    

}