using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUB : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Image hpBar;
    public Image mpBar;
    public Text hpText;
    public Text mpText;

    public void SetHUDPlayer(Unit unit)
    {
        nameText.text = unit.unitname;
        levelText.text = "Level: " + unit.level;
        hpBar.fillAmount = (float)unit.currentHP/unit.maxHP;
        mpBar.fillAmount = (float)unit.currentMP/unit.maxMP;
        hpText.text = unit.currentHP + "/" + unit.maxHP;
        mpText.text = unit.currentMP + "/" + unit.maxMP;
    }
    public void SetHUDEnemy(EnemyUnit enemyUnit)
    {
        nameText.text = enemyUnit.unitname;
        levelText.text = "Level: " + enemyUnit.level;
        hpBar.fillAmount = (float)enemyUnit.currentHP / enemyUnit.maxHP;
        mpBar.fillAmount = (float)enemyUnit.currentMP / enemyUnit.maxMP;
        hpText.text = enemyUnit.currentHP + "/" + enemyUnit.maxHP;
        mpText.text = enemyUnit.currentMP + "/" + enemyUnit.maxMP;
    }    

}
