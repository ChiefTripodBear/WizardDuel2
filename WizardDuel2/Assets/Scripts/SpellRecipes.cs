using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class SpellRecipes : ScriptableObject
{
    public enum Element { Fire, Air, Earth, Water };
    public List<Element> Elements;

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
