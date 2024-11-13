using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterStats", menuName = "Character/Stats")]
public class CharacterStats : ScriptableObject
{
    public string characterName;


    public void ShowName()
    {
        Debug.Log("Character Name: " + characterName);
    }
}