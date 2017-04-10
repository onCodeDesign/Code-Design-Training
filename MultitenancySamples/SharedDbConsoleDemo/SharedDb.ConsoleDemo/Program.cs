using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using iQuarc.SystemEx;
using SharedDb.DataAccess;

namespace SharedDb.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository rep = new Repository();

            string tenantKey = "FirstTenant";
            SetTenantKey(tenantKey);

            var tenants = rep.GetEntities<Tenant>().ToList();
            WriteToEntities("Tenants", tenantKey, tenants);


            var patients = rep.GetEntities<Patient>().ToList();
            WriteToEntities("Patients", tenantKey, patients);

            tenantKey = "SecondTenant";
            SetTenantKey(tenantKey);
            patients = rep.GetEntities<Patient>().ToList();
            WriteToEntities("Patients", tenantKey, patients);

            Console.ReadKey();
        }

        private static void SetTenantKey(string tenantKey)
        {
            var claimsIdentity = new ClaimsIdentity(
                new[] {new Claim("tenant_key", tenantKey)});
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            ClaimsPrincipal.ClaimsPrincipalSelector = () => claimsPrincipal;
        }

        private static void WriteToEntities<T>(string title, string tenantKey, IEnumerable<T> entities)
        {
            Console.WriteLine();
            Console.WriteLine($"************** {title} **********");
            Console.WriteLine($"TenantKey: {tenantKey}\n");
            foreach (var p in entities)
            {
                WriteEntity(p);
            }
        }

        private static void WriteEntity<T>(T entity)
        {
            Console.WriteLine();
            Console.WriteLine($"{typeof(T).Name}:");
            Console.WriteLine("-----------------------");
            var properties = ReflectionExtensions.GetEditableSimpleProperties(entity);
            foreach (var propertyInfo in properties)
            {
                Console.Write($"{propertyInfo.Name}: ");
                Console.WriteLine(propertyInfo.GetValue(entity));
            }

            Console.WriteLine("-----------------------------------------------------");
        }

    }
}