using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using binary we can easily compare binary strings with BitAnd to assign spell easily
[Flags] public enum Element { None = 0,             //00000000
                              Fire = 1,             //00000001
                              Air = 2,              //00000010
                              Earth = 4,            //00000100
                              Water = 8,            //00001000
                              Steam = 9,            //00001001  <- ie. water and fire
                              Gas = 3,              //00000011  <- ie. fire and air
                              Lava = 5,             //00000101
                              Ice = 10,             //00001010
                              Mud = 12,             //00001100
                              Sand = 6              //00000110
                                };

[CreateAssetMenu]
public class SpellRecipes : ScriptableObject
{
    public Element recipe;
    public Sprite _spellSprite;
    public float _force;
    public float _pierce;
    public float _toughness;
    public float _resist;
    //public float _lifecost;
    public float _spellCost;
    public bool hasEffect;
    public bool effectSelf;
    public int roundCount;
    public enum EffectStat { _force, _pierce, _resist, _toughness, life, mana, power, peek};
    public EffectStat effectStat;
    public float effectValue = 1;
}
