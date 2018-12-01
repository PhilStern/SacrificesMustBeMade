using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttributeManipulator
{

    [SerializeField]
    private AttributeType Type;
    [SerializeField]
    private int Value;

    public AttributeManipulator(AttributeType type, int value )
    {
        Value = value;
        Type = type;
    }
}
