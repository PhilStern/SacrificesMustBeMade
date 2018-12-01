using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string Name;
    public string Gender;
    public int StartTraitCount;
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
        int j = Random.Range(0, Manager.Instance.Traits.Count);
        for (int i = 0; i < StartTraitCount; i++)
        {
            while (CharacterHasTrait(Manager.Instance.Traits[j]))
            {
                j = Random.Range(0, Manager.Instance.Traits.Count);
            }
            AddTrait(new Trait(Manager.Instance.Traits[j]));
        }
    }

    public void AddTrait(Trait t)
    {
        Traits.Add(new Trait(t));
    }

    public void AddBuff(Buff b)
    {
        Buffs.Add(new Buff(b));
    }

    public VisibilityState GetAttributeVisibility(AttributeType type)
    {
        for (int i = 0; i < Attributes.Count; i++)
        {
            if (Attributes[i].GetAttributeType() == type)
            {
                return Attributes[i].Visibility;

            }
        }
        return VisibilityState.Hidden;
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

    public void LeaveTeam()
    {
        Manager.Instance.TManager.ReplacedMembers.Add(this);
        this.transform.parent = Manager.Instance.CGenerator.ReplacedCharactersTransform;
    }

    public void EnterTeam(int position)
    {
        Manager.Instance.TManager.ChooseNewMembers.Remove(this);
        this.transform.parent = Manager.Instance.CGenerator.ChooseCharacterTransform;
    }

    public void Sacrifice()
    {
        Manager.Instance.TManager.SacrificedMembers.Add(this);
        Manager.Instance.TManager.Team.Remove(this);
        this.transform.parent = Manager.Instance.CGenerator.SacrificedCharactersTransform;
    }

    public bool CharacterHasTrait(Trait trait)
    {
        bool r = false;
        foreach (Trait t in Traits)
        {
            if (t.Name == trait.Name)
            {
                r = true;
            }
        }
        return r;
    }

}
