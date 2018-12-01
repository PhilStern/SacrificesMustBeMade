using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Trait : CharacterManipulator
{

    public Trait(string name, Rating rating, List<AttributeManipulator> attributeManipulators)
    {
        Name = name;
        Rating = rating;
        AttributeManipulators = new List<AttributeManipulator>(attributeManipulators);
    }
    public Trait(Trait trait)
    {
        Name = trait.Name;
        Rating = trait.Rating;
        AttributeManipulators = new List<AttributeManipulator>(trait.AttributeManipulators);
    }

    public int GetAttributeManipulatorValue(AttributeType type)
    {
        int v = 0;
        for (int i = 0; i < AttributeManipulators.Count; i++)
        {
            if(AttributeManipulators[i].GetAttributeType() == type)
            {
                v += AttributeManipulators[i].GetValue();
            }
        }
        return v;
    }
}
