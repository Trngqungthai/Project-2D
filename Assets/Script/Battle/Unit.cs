using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Unit : MonoBehaviour
{
    public BaseHero baseHero;
    
    public string unitname;
    public int level;
    public int maxEXP;
    public int EXP;
    public int gold;
    public int attributepoint;

    public int damage;
    public int maxHP;
    public int currentHP;
    public int maxMP;
    public int currentMP;
    public int attackspeed;
    public void Awake()
    {
        CaculatorUnit();
    }
    public void CaculatorUnit()
    {
        unitname = baseHero.heroname;
        level = baseHero.level;
        maxEXP = baseHero.maxEXP;
        EXP = baseHero.EXP;
        gold = baseHero.gold;
        attributepoint = baseHero.attributepoint;
        damage = baseHero.damage;
        maxHP = baseHero.maxHP;
        currentHP = baseHero.curHP;
        maxMP = baseHero.maxMP;
        currentMP = baseHero.curMP;
        attackspeed = baseHero.attackspeed;
    }
    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        currentHP = Mathf.Max(currentHP, 0); // Đảm bảo currentHP không nhỏ hơn 0
    }
    public void UseMP(int use)
    {
        currentMP -= use;
        currentMP = Mathf.Max(currentMP, 0); // Đảm bảo currentHP không nhỏ hơn 0
    }
}
