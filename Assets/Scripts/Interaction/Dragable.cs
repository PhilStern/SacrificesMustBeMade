using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour {

    public SpriteRenderer sr;
    public Character Character;
    private Vector3 GrabPosition;
    public bool Active = true;

    private void Start()
    {
        Character = GetComponent<Character>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && Active)
        {
            if (Manager.Instance.Interaction.isDragging() == false)
                Manager.Instance.Interaction.SetDraggingObject(this);
        }
    }

    public void SetGrabPosition()
    {
        GrabPosition = transform.position;
    }

    public void ReturnToGrabPosition()
    {
        transform.position = GrabPosition;
    }

}
