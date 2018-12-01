using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour {

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Manager.Instance.Interaction.isDragging() == false)
                Manager.Instance.Interaction.SetDraggingObject(this);
        }
    }

}
