using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Trait
{

    [SerializeField]
    protected string Name;
    [SerializeField]
    protected Rating Rating;
    [SerializeField]
    protected List<AttributeManipulator> AttributeManipulators = new List<AttributeManipulator>();

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
}
