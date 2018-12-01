using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute{
    [SerializeField]
    private string Name;
    [SerializeField]
    private AttributeType Type;

    public VisibilityState Visibility;

    [SerializeField]
    private int Value;

    public Attribute(AttributeType type, int value)
    {
        if (value != -1)
        {
            Value = value;
        }
        else
        {
            Value = Random.Range(1, 10);
        }

        Type = type;
        Name = Type.ToString();
    }

    public int GetValue()
    {
        return Value;
    }

    public AttributeType GetAttributeType()
    {
        return Type;
    }
	
}
