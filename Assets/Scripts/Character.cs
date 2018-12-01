using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private List<Attribute> Attributes = new List<Attribute>();
    [SerializeField]
    private List<Trait> Traits = new List<Trait>();
    [SerializeField]
    private List<Buff> Buffs = new List<Buff>();
}
