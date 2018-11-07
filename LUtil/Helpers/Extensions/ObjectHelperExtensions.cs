using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class ObjectHelperExtensions {
        /// <inheritdoc cref="ObjectHelper.ThrowIfNull"/>
        public static void ThrowIfNull(this object value, string name = null) =>
            ObjectHelper.ThrowIfNull(value, name);

        /// <inheritdoc cref="ObjectHelper.EqualTo{T}"/>
        public static bool EqualTo<T>(this T source, params T[] any) =>
            ObjectHelper.EqualTo(source, any);
    }
}
