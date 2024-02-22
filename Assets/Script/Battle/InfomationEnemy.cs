using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfomationEnemy : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Text hpText;
    public Text mpText;

    public void SetHUD(EnemyUnit unit)
    {
        nameText.text = unit.unitname;
        levelText.text = " " + unit.level;
        hpText.text = " " + unit.maxHP;
        mpText.text = " " + + unit.maxMP;
    }
}