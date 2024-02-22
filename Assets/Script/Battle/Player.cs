using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using static Cinemachine.DocumentationSortingAttribute;

public class Player : MonoBehaviour
{
    public BaseHero baseHero;
    private void Awake()
    {
        CalculateStats();
    }
    public void CalculateStats()
    {
        baseHero.maxHP = baseHero.strength * 5 + baseHero.stamina * 50;
        baseHero.curHP = baseHero.maxHP;
        baseHero.maxMP = (baseHero.intellect * 10) + (baseHero.agility * 2);
        baseHero.curMP = baseHero.maxMP;
        baseHero.damage = baseHero.strength * 5 + baseHero.stamina * 2 + baseHero.intellect + baseHero.agility;
        baseHero.attackspeed = baseHero.agility * 5;
        
    }
    public void LevelUp()
    {
        if (baseHero.EXP >= baseHero.maxEXP)
        {
            baseHero.EXP = 0;
            baseHero.level++;
            baseHero.attributepoint++;
            baseHero.maxEXP = 200 + 10 * baseHero.level;
        }
    }
    public void UpdateStats()
    {
        CalculateStats();
        LevelUp();
    }
    private void Update()
    {
        UpdateStats();
    }
}
