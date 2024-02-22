using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BaseEnemy : ScriptableObject
{
    public string enemyname;

    public int level;
    public int exp;
    public int gold;

    public int maxHP;
    public int curHP;

    public int maxMP;
    public int curMP;

    public int damage;
    public int attackspeed;
}
