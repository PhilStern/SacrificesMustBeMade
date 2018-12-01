using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff : Trait {

    [SerializeField]
    private int Duration;
    [SerializeField]
    private int durationLeft;

    public Buff(string name, Rating rating, List<AttributeManipulator> attributeManipulators, int duration) : base( name, rating, attributeManipulators)
    {
        Name = name;
        Rating = rating;
        AttributeManipulators = new List<AttributeManipulator>(attributeManipulators);
        Duration = duration < 0 ? 0 : duration;
    }
    public Buff(Buff buff) : base(buff)
    {
        Name = buff.Name;
        Rating = buff.Rating;
        AttributeManipulators = new List<AttributeManipulator>(buff.AttributeManipulators);
        Duration = buff.Duration < 0 ? 0 : buff.Duration;
    }
}
