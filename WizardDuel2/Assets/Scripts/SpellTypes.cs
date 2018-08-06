using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellTypes : ScriptableObject
{
    public enum SpellType { offensive, defensive };
    public SpellType spelltype;
    public Sprite _typesprite;

    public float _forceMod;
    public float _pierceMod;
    public float _toughnessMod;
    public float _resistMod;

}
