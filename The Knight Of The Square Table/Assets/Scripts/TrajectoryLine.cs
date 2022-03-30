using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))] //requires the LineRendere component to execute the class

public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint, Vector2 force)
    {
        lr.positionCount = 2; //line size
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        float f = Mathf.Clamp(Mathf.Sqrt(Mathf.Pow(endPoint.x-startPoint.x,2)+ Mathf.Pow(endPoint.y - startPoint.y, 2)), 0, 1);
        //Debug.Log(Mathf.Sqrt(Mathf.Pow(endPoint.x - startPoint.x, 2) + Mathf.Pow(endPoint.y - startPoint.y, 2)));
        //Debug.Log(f);
        Color color = Color.Lerp(Color.red, Color.yellow, f);
        lr.startColor = color;
        lr.SetPositions(points);
        
    }

    public void EndLine()
    {
        lr.positionCount = 0; //makes the line dissapear
    }

    private float Max(Vector2 force)
    {
        if (force.x >= force.y)
        {
            return force.x;
        }
        else if (force.x < force.y)
        {
            return force.y;
        }
        return force.x;
    }
}
