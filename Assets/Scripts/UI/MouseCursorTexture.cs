using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorTexture : MonoBehaviour
{

    public Texture2D cursorTexture;

    // Use this for initialization
    void Start ()
    {
        Vector2 vector = new Vector2(cursorTexture.width, 0);
        Cursor.SetCursor(cursorTexture, vector, CursorMode.ForceSoftware);
	}
	
}
