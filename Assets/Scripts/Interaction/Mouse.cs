using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mouse : MonoBehaviour
{
    private Dragable DragingObject;
    private Targetable TargetObject;
    private Vector3 mousePosition;
    

    public void SetDraggingObject(Dragable d)
    {
        DragingObject = d;
        DragingObject.sr.sortingOrder = 2;
        DragingObject.gameObject.layer = 2;
        DragingObject.SetGrabPosition();
    }

    public void SetTargetObject(Targetable t)
    {
        TargetObject = t;
    }

    public void ReleaseDraggingObject()
    {
        DragingObject.gameObject.layer = 0;
        DragingObject.sr.sortingOrder = 0;
        DragingObject.ReturnToGrabPosition();
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
        
            if (Input.GetMouseButtonUp(0))
            {
                if (DragingObject.Character != null && hasTarget() && TargetObject.Character != null)
                {
                    Manager.Instance.TManager.SwitchTeamCharacter(TargetObject.Character, DragingObject.Character);
                    DragingObject.gameObject.layer = 0;
                    DragingObject.sr.sortingOrder = 0;
                    DragingObject = null;
                    ReleaseTargetObject();
                }
                else
                {
                    ReleaseDraggingObject();
                    ReleaseTargetObject();
                }
            }
        }
    }



}
