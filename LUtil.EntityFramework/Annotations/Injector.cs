using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace LUtil.EntityFramework.Annotations {
    [PublicAPI]
    public static class Injector {
        /// <summary>
        ///     Implements the extra Annotation's behaviors. This must be called
        ///     in the <see cref="DbContext.OnModelCreating"/> method.
        /// </summary>
        /// <param name="builder">The builder to inject behavior into.</param>
        public static void InjectLUtilAnnotations(this ModelBuilder builder) {
            foreach (var entity in builder.Model.GetEntityTypes()) {
                // OnDelete
                foreach (var fk in entity.GetForeignKeys()) {
                    var behaviorAttribute = fk.Properties
                        .Select(p => p.PropertyInfo.GetCustomAttribute<OnDeleteAttribute>())
                        .FirstOrDefault(p => p != null);
                    if (behaviorAttribute != null) {
                        fk.DeleteBehavior = behaviorAttribute.Behavior;
                    }
                }
                // Unique
                foreach (var prop in entity.GetProperties()) {
                    var uniqueAttribute = prop.PropertyInfo.GetCustomAttribute<UniqueAttribute>();
                    if (uniqueAttribute != null) {
                        if (uniqueAttribute.Columns.Any()) {
                            // Compound
                            entity.AddIndex(
                                entity.GetProperties().Where(p => uniqueAttribute.Columns.Contains(p.Name))
                                    .Concat(new[] { prop }).ToList()
                            ).IsUnique = true;
                        } else {
                            // Single
                            entity.AddIndex(prop).IsUnique = true;
                        }
                    }
                }
            }
        }
    }
}
