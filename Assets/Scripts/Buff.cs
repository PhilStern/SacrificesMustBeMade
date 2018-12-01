using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff : CharacterManipulator
{

    [SerializeField]
    private int Duration;
    [SerializeField]
    private int durationLeft;

    public Buff(string name, Rating rating, List<AttributeManipulator> attributeManipulators, int duration) 
    {
        Name = name;
        Rating = rating;
        AttributeManipulators = new List<AttributeManipulator>(attributeManipulators);
        Duration = duration < 0 ? 0 : duration;
    }
    public Buff(Buff buff) 
    {
        Name = buff.Name;
        Rating = buff.Rating;
        AttributeManipulators = new List<AttributeManipulator>(buff.AttributeManipulators);
        Duration = buff.Duration < 0 ? 0 : buff.Duration;
    }

    public int GetAttributeManipulatorValue(AttributeType type)
    {
        int v = 0;
        if (durationLeft != 0)
        {
            for (int i = 0; i < AttributeManipulators.Count; i++)
            {
                if (AttributeManipulators[i].GetAttributeType() == type)
                {
                    v += AttributeManipulators[i].GetValue();
                }
            }
        }
        return v;
    }
}
