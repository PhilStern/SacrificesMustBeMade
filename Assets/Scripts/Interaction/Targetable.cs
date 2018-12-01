using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour {
    Mouse m;
    private void Start()
    {
        m = Manager.Instance.Interaction;
    }

    private void OnMouseEnter()
    {
        if (m.isDragging() && m.GetDragableTransform() != transform && m.hasTarget() == false )
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
