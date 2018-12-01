using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string Name;
    public string Gender;
    public List<Attribute> Attributes = new List<Attribute>();
    [SerializeField]
    protected List<Trait> Traits = new List<Trait>();
    [SerializeField]
    protected List<Buff> Buffs = new List<Buff>();

    public void GenerateAttributes()
    {
        Attributes.Add(new Attribute(AttributeType.Body, Random.Range(0, 10)));
        Attributes.Add(new Attribute(AttributeType.Mind, Random.Range(0, 10)));
        Attributes.Add(new Attribute(AttributeType.Wealth, Random.Range(0, 10)));
    }

    public void AddTrait(Trait t)
    {
        Traits.Add(new Trait(t));
    }

    public void AddBuff(Buff b)
    {
        Buffs.Add(new Buff(b));
    }

    public int GetAttributeValue(AttributeType type)
    {
        int a = 0;
        for(int i = 0; i < Attributes.Count; i++)
        {
            if (Attributes[i].GetAttributeType() == type)
            {
                a += Attributes[i].GetValue();
            }
        }
        for (int i = 0; i < Traits.Count; i++)
        {
                a += Traits[i].GetAttributeManipulatorValue(type);
        }
        for (int i = 0; i < Buffs.Count; i++)
        {
            a += Buffs[i].GetAttributeManipulatorValue(type);
        }

        return a;
    }


}
