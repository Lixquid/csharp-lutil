namespace LUtil.Helpers.Extensions {
    public static class ObjectHelperExtensions {
        /// <inheritdoc cref="ObjectHelper.ThrowIfNull"/>
        public static void ThrowIfNull(this object value, string name = null) =>
            ObjectHelper.ThrowIfNull(value, name);
    }
}
