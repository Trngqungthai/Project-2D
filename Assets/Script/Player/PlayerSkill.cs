using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public string skillName;    
    public int skillLevel;
    public int damge;
    public int useMP;
    public int damgepercent;
    public BaseHero baseHero;
    public PlayerSkill Skill1()
    {
        
        PlayerSkill skill = new PlayerSkill();
        skill.skillName = "Mưa Đá";
        skill.skillLevel = 1;
        skill.damgepercent = 120;
        skill.damge = baseHero.damage * (skill.damgepercent / 100);
        Debug.Log("baseHero damge: " + baseHero.damage);
        skill.useMP = 20;
        Debug.Log("damge: " + skill.damge);
        return skill;
    }
    public PlayerSkill Skill2()
    {
        PlayerSkill skill = new PlayerSkill();
        skill.skillName = "Hỏa Thiêu";
        skill.skillLevel = 1;
        skill.damgepercent = 150;
        skill.damge = baseHero.damage * (skill.damgepercent / 100);
        skill.useMP = 30;
        return skill;
    }
    public PlayerSkill Skill3()
    {
        PlayerSkill skill = new PlayerSkill();
        skill.skillName = "Bùm Chíu";
        skill.skillLevel = 1;
        skill.damgepercent = 200;
        skill.damge = baseHero.damage * (skill.damgepercent / 100);
        skill.useMP = 50;
        return skill;
    }
    public PlayerSkill Skill4()
    {
        PlayerSkill skill = new PlayerSkill();
        skill.skillName = "Tất Sát Kỹ";
        skill.skillLevel = 1;
        skill.damgepercent = 9999;
        skill.damge = baseHero.damage * (skill.damgepercent / 100);
        skill.useMP = 50;
        return skill;
    }  
}
