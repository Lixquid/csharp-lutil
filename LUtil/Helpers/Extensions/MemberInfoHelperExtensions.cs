using System;
using System.Reflection;
using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class MemberInfoHelperExtensions {
        /// <inheritdoc cref="MemberInfoHelper.GetMemberType(MemberInfo)"/>
        public static Type GetMemberType([NotNull] this MemberInfo member) =>
            MemberInfoHelper.GetMemberType(member);

        /// <inheritdoc cref="MemberInfoHelper.GetValue"/>
        public static object GetValue([NotNull] this MemberInfo member, [NotNull] object instance) =>
            MemberInfoHelper.GetValue(member, instance);

        /// <inheritdoc cref="MemberInfoHelper.SetValue"/>
        public static void SetValue([NotNull] this MemberInfo member, [NotNull] object instance, object value) =>
            MemberInfoHelper.SetValue(member, instance, value);
    }
}
