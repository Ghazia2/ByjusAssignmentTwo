using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightArm : MonoBehaviour
{
    public Texture2D moveCursor;
    public Texture2D rotateCursor;
    public Text infoText;
    public bool rotateMode = false;
    public GameObject drawGameObject;
    public Transform compass;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!rotateMode)
            {
                rotateMode = true;
                infoText.text = "<color=green>ROTATE MODE</color>";
            }
            else
            {
                rotateMode = false;
                infoText.text = "<color=red>EDIT MODE</color>";
                FindObjectOfType<Draw>().canDraw = false;
            }
        }
    }

    void OnMouseOver()
    {
        if(!rotateMode)
            Cursor.SetCursor(moveCursor, Vector2.zero, CursorMode.Auto);
        if(rotateMode)
            Cursor.SetCursor(rotateCursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseDown()
    {
        if(rotateMode)
            FindObjectOfType<Draw>().CreateBrush();
    }
    private void OnMouseDrag()
    {
        if(rotateMode)
        {
            drawGameObject.GetComponent<Draw>().canDraw = true;
            Vector3 pos = Camera.main.WorldToScreenPoint(compass.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            compass.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x > 8f)
                mousePos.x = 8;
            if (mousePos.y > 8f)
                mousePos.y = 8f;
            transform.position = mousePos;
        }
    }
    void OnMouseExit() => Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
}
