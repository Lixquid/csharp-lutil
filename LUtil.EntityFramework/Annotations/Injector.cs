using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
                        .Select(p => p.PropertyInfo.GetCustomAttribute<OnDeleteAttribute>(true))
                        .FirstOrDefault(p => p != null);
                    if (behaviorAttribute != null) {
                        fk.DeleteBehavior = behaviorAttribute.Behavior;
                    }
                }
                var keyProperties = new List<(int order, IMutableProperty prop)>();
                foreach (var prop in entity.GetProperties()) {
                    // Unique
                    var uniqueAttribute = prop.PropertyInfo.GetCustomAttribute<UniqueAttribute>(true);
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

                    // CompoundKey
                    var compoundKey = prop.PropertyInfo.GetCustomAttribute<CompoundKeyAttribute>(true);
                    if (compoundKey != null) {
                        keyProperties.Add((compoundKey.Order, prop));
                    }
                }

                if (keyProperties.Count > 0) {
                    keyProperties.Sort((a, b) => a.order.CompareTo(b.order));
                    entity.SetPrimaryKey(keyProperties.Select(x => x.prop).ToList());
                }
            }
        }
    }
}
