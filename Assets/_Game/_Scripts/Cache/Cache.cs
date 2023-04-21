using System.Collections.Generic;
using UnityEngine;
using System;

public static class Cache
{
    public static Dictionary<Collider, Character> dictionPlayer = new Dictionary<Collider, Character>();

    public static Character GetCharacter(Collider collider)
    {
        if (!dictionPlayer.ContainsKey(collider))
        {
            dictionPlayer.Add(collider,collider.GetComponent<Character>());
        }
        return dictionPlayer[collider];
    }

    public static Dictionary<Collider, Collider> collider = new Dictionary<Collider, Collider>();
    public static Collider GetCollider(Collider other)
    {
        if (!collider.ContainsKey(other))
        {
            collider.Add(other, other.GetComponent<Collider>());
        }
        return collider[other];
    }
}