using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using binary we can easily compare binary strings with BitAnd to assign spell easily
[Flags] public enum SType
{
    None = 0,              //00000000 
    Ball = 1,             //00000001
    Bolt = 2,             //00000010
    Shield = 4,              //00000100
    Wall = 8,            //00001000

};

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
