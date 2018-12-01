using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mouse : MonoBehaviour
{
    private Dragable DragingObject;
    private Targetable TargetObject;
    private Vector3 mousePosition;
    public UnityEvent OnDroppedOnTarget;

    public void SetDraggingObject(Dragable d)
    {
        DragingObject = d;
    }

    public void SetTargetObject(Targetable t)
    {
        TargetObject = t;
    }

    public void ReleaseDraggingObject()
    {
        DragingObject = null;
    }

    public void ReleaseTargetObject()
    {
        TargetObject = null;
    }

    public Transform GetDragableTransform()
    {
        return DragingObject.transform;
    }

    public Targetable GetTargetable()
    {
        return TargetObject;
    }

    public bool isDragging()
    {
        return DragingObject != null;
    }

    public bool hasTarget()
    {
        return TargetObject != null;
    }


    private void Update()
    {
        if (isDragging())
        {
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            DragingObject.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging() && hasTarget() == false)
            {
                ReleaseDraggingObject();
            }
            else if (hasTarget())
            {
                if (OnDroppedOnTarget != null)
                {
                    OnDroppedOnTarget.Invoke();
                    ReleaseDraggingObject();
                    ReleaseTargetObject();
                }
            }
        }
    }



}
