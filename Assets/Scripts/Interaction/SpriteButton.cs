using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteButton : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public Sprite Base;
    public Sprite Hover;
    public Sprite Click;

    public UnityEvent OnClicked;

    [SerializeField]
    private bool hover = false;

 

    private void OnMouseOver()
    {

        if (Input.GetMouseButton(0))
        {
            spriteRenderer.sprite = Click;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (OnClicked != null)
                OnClicked.Invoke();
        }
        else
        {
            spriteRenderer.sprite = Hover;
        }
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = Base;
    }



}
