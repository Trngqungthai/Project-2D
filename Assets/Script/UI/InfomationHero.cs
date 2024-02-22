using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfomationHero : MonoBehaviour
{
    public BaseHero baseHero;
    public Text nameText;
    public Text levelText;
    public Text expText;
    public Text hpText;
    public Text mpText;
    public Text damageText;
    public Text atkSpeedText;
    public Text attpointText;
    public Text strText;
    public Text staText;
    public Text intText;
    public Text ageText;
    public void Update()
    {
        nameText.text = baseHero.heroname;
        levelText.text = "Level: " + baseHero.level;
        expText.text = baseHero.EXP + "/" + baseHero.maxEXP;
        hpText.text = "" + baseHero.maxHP;
        mpText.text = "" + baseHero.maxMP;
        damageText.text = "" + baseHero.damage;
        atkSpeedText.text = "" + baseHero.attackspeed;
        attpointText.text = "" + baseHero.attributepoint;
        strText.text = "Strength : " + baseHero.strength;
        staText.text = "Stamina : " + baseHero.stamina;
        intText.text = "Intellect : " + baseHero.intellect;
        ageText.text = "Agility : " + baseHero.agility;
    }
}
