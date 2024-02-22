using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIPlayer : MonoBehaviour
{
    public BaseHero baseHero;
    public Text nameText;
    public Text levelText;
    public Image hpBar;
    public Image mpBar;
    public Text hpText;
    public Text mpText;
    public void Update()
    {
        nameText.text = baseHero.heroname;
        levelText.text = "Level: " + baseHero.level;
        hpBar.fillAmount = (float)baseHero.maxHP/ (float)baseHero.maxHP;
        mpBar.fillAmount = (float)baseHero.maxMP/ (float)baseHero.maxMP;
        hpText.text = "" + baseHero.maxHP;
        mpText.text = "" + baseHero.maxMP;
    }
    
}
