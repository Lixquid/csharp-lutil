using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class TypeHelperExtensions {
        /// <inheritdoc cref="TypeHelper.GetAllImplementedTypes"/>
        public static ISet<Type> GetAllImplementedTypes([NotNull] this Type type, bool withUnboundGenerics = false) =>
            TypeHelper.GetAllImplementedTypes(type);
    }
}
