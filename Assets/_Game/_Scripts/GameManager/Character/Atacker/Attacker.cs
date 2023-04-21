using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public List<Character> listCharacterInRange = new List<Character>();
    public Transform tF;
    private void Awake()
    {
        tF = transform;
    }

    public Character GetCharacterRange()
    {
        if (listCharacterInRange.Count <= 0) return null;

        Character character = new Character();
        float minDistance = float.MaxValue;
        for (int i = 0; i < listCharacterInRange.Count; i++)
        {
            float distance = Vector3.Distance(tF.position, listCharacterInRange[i].transform.position);
            if (minDistance > distance)
            {
                minDistance = distance;
                character = listCharacterInRange[i];
            }
        }
        if (character.isDie)
        {
            listCharacterInRange.Remove(character);
            return null;
        }
        return character;
    }
    private void OnTriggerEnter(Collider other)
    {
        Character character = Cache.GetCharacter(other);
        if (other.CompareTag(Constans.TAG_ENEMY) || other.CompareTag(Constans.TAG_PLAYER))
        {
            if (character.isDie)
            {
                listCharacterInRange.Remove(character);
            }
            else
            {
                listCharacterInRange.Add(character);
            }
              
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Character character = Cache.GetCharacter(other);
        if (other.CompareTag(Constans.TAG_ENEMY) || other.CompareTag(Constans.TAG_PLAYER))
        {
            listCharacterInRange.Remove(character);
        }
    }
}
