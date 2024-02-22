using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttributeAllocation : MonoBehaviour
{
    public BaseHero baseHero;
    public Button addStr;
    public Button addSta;
    public Button addInt;
    public Button addAgi;
    public void AddStrClick()
    {
        if (baseHero.attributepoint > 0)
        {
            baseHero.attributepoint--;
            baseHero.attributepoint = Mathf.Max(baseHero.attributepoint, 0);
            baseHero.strength++;
        }
    }
    public void AddStaClick()
    {
        if (baseHero.attributepoint > 0)
        {
            baseHero.attributepoint--;
            baseHero.attributepoint = Mathf.Max(baseHero.attributepoint, 0);
            baseHero.stamina++;
        }
    }
    public void AddIntClick()
    {
        if (baseHero.attributepoint > 0)
        {
            baseHero.attributepoint--;
            baseHero.attributepoint = Mathf.Max(baseHero.attributepoint, 0);
            baseHero.intellect++;
        }
    }
    public void AddAgiClick()
    {
        if (baseHero.attributepoint > 0)
        {
            baseHero.attributepoint--;
            baseHero.attributepoint = Mathf.Max(baseHero.attributepoint, 0);
            baseHero.agility++;
        }
    }
}
