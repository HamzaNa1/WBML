using System;
using System.Linq;
using System.Reflection;

namespace WBML.Utility;

public static class ObjectExtensions
{
    
    public static void CallMethod(this object o, string methodName, params object[] args)
    {
        Type[] types = args.Select(x => x.GetType()).ToArray();
        MethodInfo info = o.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic, null, types, null);

        info?.Invoke(o, args);
    }

    public static T CallMethod<T>(this object o, string methodName, params object[] args)
    {
        Type[] types = args.Select(x => x.GetType()).ToArray();
        MethodInfo info = o.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic, null, types, null);

        return (T)(info != null ? info.Invoke(o, args) : null);
    }

    public static void CallStaticMethod(Type type, string methodName, params object[] args)
    {
        MethodInfo info = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);
        info?.Invoke(null, args);
    }
    
    public static T CallStaticMethod<T>(Type type, string methodName, params object[] args)
    {
        MethodInfo info = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);
        return (T)(info != null ? info.Invoke(null, args) : null);
    }

    public static T GetField<T>(this object o, string fieldName)
    {
        FieldInfo info = o.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        return (T)(info != null ? info.GetValue(o) : null);
    }
    
    public static object GetField(this object o, string fieldName)
    {
        FieldInfo info = o.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        return info != null ? info.GetValue(o) : null;
    }

    public static void SetField<T>(this object o, string fieldName, T newValue)
    {
        FieldInfo info = o.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        info?.SetValue(o, newValue);
    }
}