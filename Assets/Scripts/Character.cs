using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string Name;
    public string Gender;
    [SerializeField]
    protected List<Attribute> Attributes = new List<Attribute>();
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


}
