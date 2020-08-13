using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WepAPI.Infra.Data;
using WebAPI.Util;

namespace WebAPI.Infra.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SqlContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var pass = new Password();
            var admin = new User()
            {
                Active = true,DateInsert = DateTime.Now, Email = "admin@imdb.com.br",
                isAdmin = true, Login = "admin", Password = pass.CreateSecurePassword("admin"), Name = "Administrador"
            };
            //var verificar = pass.VerifyHash("admin", Convert.FromBase64String(admin.Password.Split("..")[0]), Convert.FromBase64String(admin.Password.Split("..")[1]));

            context.Users.Add(admin);
            context.SaveChanges();
        }
    }
}
