using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LUtil.Helpers.Extensions;

namespace LUtil.Helpers {
    [PublicAPI]
    public static class TypeHelper {
        /// <summary>
        ///     Returns the set of types that a type and all of its base types
        ///     / interfaces implement.
        /// </summary>
        /// <param name="type">The type to get types for.</param>
        /// <param name="withUnboundGenerics">
        ///     If set, the unbound generics (types of the form
        ///     <c>typeof(IEnumerable&lt;&gt;)</c>) of returned generics will
        ///     also be included in the output.
        /// </param>
        public static ISet<Type> GetAllImplementedTypes([NotNull] Type type, bool withUnboundGenerics = false) {
            type.ThrowIfNull(nameof(type));

            var output = new HashSet<Type>();
            foreach (var subtype in type.GetInterfaces().Concat(new[] { type.BaseType })) {
                if (subtype == null || output.Contains(subtype))
                    continue;
                output.Add(subtype);
                output.UnionWith(GetAllImplementedTypes(subtype));
                if (withUnboundGenerics && subtype.IsGenericType) {
                    output.Add(subtype.GetGenericTypeDefinition());
                    output.UnionWith(GetAllImplementedTypes(subtype.GetGenericTypeDefinition()));
                }
            }

            return output;
        }
    }
}
