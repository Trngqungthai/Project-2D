using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public BaseEnemy baseEnemy;
    public BaseHero baseHero;
    public string unitname;
    public int level;
    public int damage;
    public int maxHP;
    public int currentHP;
    public int maxMP;
    public int currentMP;
    public int attackspeed;
    public int minGold; 
    public int maxGold;
    public void Awake()
    {
        CaculatorUnit();
    }
    public void CaculatorUnit()
    {
        unitname = baseEnemy.enemyname;
        level = baseEnemy.level;
        damage = baseEnemy.damage;
        maxHP = baseEnemy.maxHP;
        currentHP = baseEnemy.curHP;
        maxMP = baseEnemy.maxMP;
        currentMP = baseEnemy.curMP;
        attackspeed = baseEnemy.attackspeed;
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
    public void Die()
    {
        baseEnemy.gold = Random.Range(minGold, maxGold + 1);
        baseHero.gold += baseEnemy.gold;
        baseHero.EXP += baseEnemy.exp;
    }
}
