using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinge : MonoBehaviour
{
    public Texture2D moveCursor;
    public Transform compass;

    void OnMouseEnter() => Cursor.SetCursor(moveCursor, Vector2.zero, CursorMode.Auto);
    private void OnMouseDown()
    {
        FindObjectOfType<Draw>().canDraw = false;
    }
    void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        compass.position = mousePos;
    }

    private void OnMouseUp()
    {
        if (FindObjectOfType<RightArm>().rotateMode)
            FindObjectOfType<Draw>().canDraw = true;
    }
    void OnMouseExit() => Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
}
