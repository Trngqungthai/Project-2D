using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BaseHero : ScriptableObject
{
    public string heroname;

    public int level;
    public int maxEXP;
    public int EXP;
    public int gold;
    public int attributepoint;

    public int maxHP;
    public int curHP;

    public int maxMP;
    public int curMP;

    public int damage;
    public int attackspeed;

    public int strength;//sức mạnh
    public int stamina;//thể lực
    public int intellect;//trí tuệ
    public int agility;//nhanh nhẹn

    internal void Reset()
    {
        heroname = "Ron";
        level = 1;
        maxEXP = 500;
        EXP = 0;
        gold = 0;
        attributepoint = 0;
        attackspeed = 0;
        strength = 5;
        stamina = 5;
        intellect = 5;
        agility = 5;
        CalculateStats();
    }

    public void CalculateStats()
    {
        maxHP = strength * 5 + stamina * 50;
        curHP = maxHP;

        maxMP = intellect * 10 + agility * 2;
        curMP = maxMP;

        damage = strength * 5 + stamina * 2 + intellect + agility;
        attackspeed = agility * 5;
    }

    public void LevelUp()
    {
        if (EXP >= maxEXP)
        {
            EXP = EXP - maxEXP;
            level++;
            attributepoint++;
            maxEXP = 500 + level * 10;
        }
    }

    internal void CopyFrom(BaseHero loadedHero)
    {
        name = loadedHero.name;
        level = loadedHero.level;
        maxEXP = loadedHero.maxEXP;
        EXP = loadedHero.EXP;
        maxHP = loadedHero.maxHP;
        maxMP = loadedHero.maxMP;
        attributepoint = loadedHero.attributepoint;
        gold = loadedHero.gold;
        damage = loadedHero.damage;
        attackspeed = loadedHero.attackspeed;
        strength = loadedHero.strength;
        stamina = loadedHero.stamina;
        intellect = loadedHero.intellect;
        agility = loadedHero.agility;
    }
}

