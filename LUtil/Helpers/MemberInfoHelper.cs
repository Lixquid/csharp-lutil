using System;
using System.Reflection;

namespace LUtil.Helpers {
    public static class MemberInfoHelper {
        /// <summary>
        ///     Returns the <see cref="Type"/> of the member. Only works with
        ///     <see cref="FieldInfo"/>, <see cref="PropertyInfo"/>, or
        ///     <see cref="EventInfo"/>.
        /// </summary>
        /// <param name="member">
        ///     The member to return the Type of.
        /// </param>
        /// <returns>
        ///     The type of the member.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="member"/> is not a
        ///     <see cref="FieldInfo"/>, <see cref="PropertyInfo"/>, or
        ///     <see cref="EventInfo"/>.
        /// </exception>
        public static Type GetMemberType(MemberInfo member) {
            switch (member.MemberType) {
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                case MemberTypes.Event:
                    return ((EventInfo)member).EventHandlerType;
            }

            throw new ArgumentException(
                "MemberInfo must be of type FieldInfo, PropertyInfo, or" +
                " EventInfo.",
                nameof(member)
            );
        }

        /// <summary>
        ///     Returns the value of the member. Only works with
        ///     <see cref="FieldInfo"/> and <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="member">
        ///     The member to get the value of.
        /// </param>
        /// <param name="instance">
        ///     The instance of the class that defines the
        ///     <paramref name="member"/>.
        /// </param>
        /// <returns>
        ///     The value of the member for that <paramref name="instance"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="member"/> is not a
        ///     <see cref="FieldInfo"/> or <see cref="PropertyInfo"/>.
        /// </exception>
        public static object GetValue(MemberInfo member, object instance) {
            switch (member.MemberType) {
                case MemberTypes.Field:
                    return ((FieldInfo)member).GetValue(instance);
                case MemberTypes.Property:
                    return ((PropertyInfo)member).GetValue(instance);
            }

            throw new ArgumentException(
                "MemberInfo must be of type FieldInfo or PropertyInfo.",
                nameof(member)
            );
        }

        /// <summary>
        ///     Sets the value of the member. Only works with
        ///     <see cref="FieldInfo"/> and <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="member">
        ///     The member to set the value of.
        /// </param>
        /// <param name="instance">
        ///     The instance of the class that defines the
        ///     <paramref name="member"/>.
        /// </param>
        /// <param name="value">
        ///     The value to set the member to.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="member"/> is not a
        ///     <see cref="FieldInfo"/> or <see cref="PropertyInfo"/>.
        /// </exception>
        public static void SetValue(MemberInfo member, object instance, object value) {
            switch (member.MemberType) {
                case MemberTypes.Field:
                    ((FieldInfo)member).SetValue(instance, value);
                    return;
                case MemberTypes.Property:
                    ((PropertyInfo)member).SetValue(instance, value);
                    return;
            }

            throw new ArgumentException(
                "MemberInfo must be of type FieldInfo or PropertyInfo.",
                nameof(member)
            );
        }
    }
}
