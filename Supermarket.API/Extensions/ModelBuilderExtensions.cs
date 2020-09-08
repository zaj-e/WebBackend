using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Supermarket.API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplySnakeCaseNamingConvention(this ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().toSnakeCase());
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().toSnakeCase());
                }
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().toSnakeCase());
                }
                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().toSnakeCase());
                }
                foreach (var index in entity.GetIndexes())
                {
                    index.SetName(index.GetName().toSnakeCase());
                }
            }
        }
    }
}
