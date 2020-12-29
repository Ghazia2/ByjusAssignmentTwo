using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject brush;
    public GameObject centerPrefab;
    public Transform center;
    public Transform target;
    public bool canDraw =false;
    LineRenderer currentLineRenderer;
    Vector2 lastPos;

    private void Start() => canDraw = false;
    private void Update() => DrawLine();

    void DrawLine()
    {
        if(canDraw)
        {
            if (Input.GetMouseButtonDown(0))
                CreateBrush();
            if (Input.GetMouseButton(0))
            {
                Vector2 pos = target.TransformPoint(Vector3.zero);
                if (GetDistance(pos,lastPos) > 0.001f)
                {
                    AddPoint(pos);
                    lastPos = pos;
                }
            }
            else
                currentLineRenderer = null;
        }
    }

    float GetDistance(Vector2 pt1,Vector2 pt2)
    {
        float distance = Vector2.Distance(pt1, pt2);
        return distance;
    }

    public void CreateBrush()
    {
        // Diplay CenterPoint
        GameObject centerPoint = Instantiate(centerPrefab);
        centerPoint.transform.position = center.position;

        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 Pos = target.TransformPoint(Vector3.zero);
        currentLineRenderer.SetPosition(0, Pos);
        currentLineRenderer.SetPosition(1, Pos);
    }

    void AddPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}
