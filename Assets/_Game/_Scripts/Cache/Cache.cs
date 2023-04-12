using System.Collections.Generic;
using UnityEngine;
using System;

public static class Cache
{
    public static Dictionary<System.Type, Component> diction = new Dictionary<Type, Component>();

    public static T GetComponent<T>(GameObject gameObject) where T : Component
    {
        System.Type type = typeof(T);
        if (!diction.ContainsKey(type))
        {
            T component = gameObject.GetComponent<T>();
            diction.Add(type, component);
        }
        return (T)diction[type];
    }
}