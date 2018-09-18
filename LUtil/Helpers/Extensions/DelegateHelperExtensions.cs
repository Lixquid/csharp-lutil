using System;
using System.Collections.Generic;

namespace LUtil.Helpers.Extensions {
    public static class DelegateHelperExtensions {

        public static IEnumerable<object> InvokeAll(this MulticastDelegate @delegate, params object[] args) =>
            DelegateHelper.InvokeAll(@delegate, args);

        #region Func Overloads
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<TResult>(this Func<TResult> func) =>
            DelegateHelper.InvokeAll(func);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T, TResult>(this Func<T, TResult> func, T arg1) =>
            DelegateHelper.InvokeAll(func, arg1);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult>
            InvokeAll<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 arg1, T2 arg2) =>
            DelegateHelper.InvokeAll(func, arg1, arg2);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 arg1,
            T2 arg2, T3 arg3) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, TResult>(
            this Func<T1, T2, T3, T4, T5, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6,
            T7 arg7) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
            T6 arg6, T7 arg7, T8 arg8) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
            T6 arg6, T7 arg7, T8 arg8, T9 arg9) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4,
            T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4,
            T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func, T1 arg1, T2 arg2, T3 arg3,
            T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);

        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        /// <inheritdoc cref="InvokeAll(MulticastDelegate,object[])"/>
        public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) =>
            DelegateHelper.InvokeAll(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        #endregion
    }
}
