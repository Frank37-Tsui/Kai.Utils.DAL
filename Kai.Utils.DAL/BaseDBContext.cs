using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kai.Utils.DAL
{
    public class BaseDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = Assembly.GetEntryAssembly().GetTypes()
                        .Where(type => !String.IsNullOrEmpty(type.Namespace))
                        .Where(type => type.GetTypeInfo().BaseType != null && type.GetTypeInfo().BaseType == typeof(BaseEntity));

            foreach (var type in entityTypes)
            {
                if (modelBuilder.Model.FindEntityType(type) == null)
                {
                    modelBuilder.Model.AddEntityType(type);
                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
