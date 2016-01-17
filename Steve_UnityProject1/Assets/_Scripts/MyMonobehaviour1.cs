using UnityEngine;
using System.Collections;

public class MyMonobehaviour1 : MonoBehaviour
{
    LineRenderer lineRenderer;
    void Start()
    {
        MakeLine();
        MakeLine();
        MakeLine();
        MakeLine();
        MakeLine();

    }

    void Update()
    {

    }

    Vector3 offset = Vector3.one;
    void MakeLine()
    {
        GameObject go = new GameObject();
        lineRenderer = go.AddComponent<LineRenderer>();
        lineRenderer.SetVertexCount(3);
        Vector3[] positions = new Vector3[3];
        positions[0] = Vector3.one + offset;
        positions[1] = positions[0] + Vector3.one;
        positions[2] = positions[1] + Vector3.one;
        lineRenderer.SetPositions(positions);
        
        lineRenderer.useWorldSpace = false;
        offset += Vector3.one;

        go.transform.SetParent(gameObject.transform);
    }
}
