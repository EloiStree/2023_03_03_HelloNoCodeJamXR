using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class E_ReflectionCS : MonoBehaviour
{



    public static IEnumerable<Type> GetEnumerableOfTypeThroughAssemblies<T>() where T : class
    {
        return GetEnumerableOfTypeInAssemblies<T>(AppDomain.CurrentDomain.GetAssemblies());
    }
    public static IEnumerable<Type> GetEnumerableOfTypeInAssemblies<T>(params Assembly[] assemblies) where T : class
    {
        return assemblies
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(T)));
    }
    public static IEnumerable<Type> GetEnumerableOfInterfaceThroughAssemblies<T>() 
    {
        return GetEnumerableOfInterfaceInAssemblies<T>(AppDomain.CurrentDomain.GetAssemblies());
    }
    public static IEnumerable<Type> GetEnumerableOfInterfaceInAssemblies<T>(params Assembly[] assemblies)
    {
        return assemblies
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => typeof(T).IsAssignableFrom(type));
    }




    //public static IEnumerable<T> GetEnumerableOfTypeInProject<T>(params object[] constructorArgs) where T : class, IComparable<T>
    //{
    //    List<T> objects = new List<T>();
    //    foreach (Type type in
    //        Assembly.GetAssembly(typeof(T)).GetTypes()
    //        .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
    //    {
    //        objects.Add((T)Activator.CreateInstance(type, constructorArgs));
    //    }
    //    objects.Sort();
    //    return objects;
    //}




}
