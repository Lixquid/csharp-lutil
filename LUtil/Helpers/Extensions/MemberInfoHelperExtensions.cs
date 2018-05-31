using System;
using System.Reflection;

namespace LUtil.Helpers.Extensions {
    public static class MemberInfoHelperExtensions {
        /// <inheritdoc cref="MemberInfoHelper.GetType(System.Reflection.MemberInfo)"/>
        public static Type GetMemberType( this MemberInfo member ) =>
            MemberInfoHelper.GetMemberType( member );

        /// <inheritdoc cref="MemberInfoHelper.GetValue"/>
        public static object GetValue( this MemberInfo member, object instance ) =>
            MemberInfoHelper.GetValue( member, instance );

        /// <inheritdoc cref="MemberInfoHelper.SetValue"/>
        public static void SetValue( this MemberInfo member, object instance, object value ) =>
            MemberInfoHelper.SetValue( member, instance, value );
    }
}
