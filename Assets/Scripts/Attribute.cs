using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute{
    [SerializeField]
    private string Name;
    [SerializeField]
    private AttributeType Type;
    private int maxValue = 15;
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
	
}
