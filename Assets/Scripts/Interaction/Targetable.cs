using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour {
    private Mouse m;
    public Character Character;
    public bool Active = true;

    private void Start()
    {
        m = Manager.Instance.Interaction;
        Character = GetComponent<Character>();
    }

    private void OnMouseEnter()
    {
        if (Active && m.isDragging() && m.GetDragableTransform() != transform && m.hasTarget() == false )
        {
            m.SetTargetObject(this);
        }
    }

    private void OnMouseExit()
    {
        if (m.hasTarget() && m.GetTargetable() == this)
        {
            m.ReleaseTargetObject();
        }
    }



}
