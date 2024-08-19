using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawingTwoPoint : MonoBehaviour
{
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();
    private List<EdgeCollider2D> edgeColliders = new List<EdgeCollider2D>();
    private LineRenderer currentLineRenderer;
    private EdgeCollider2D currentEdgeCollider;
    private Vector2 startPos;
    private Vector2 endPos;
    [SerializeField] private LaserCaster laserCaster;
    [SerializeField] private Material lineMaterial;

    [SerializeField] private int maxLines = 5;

    void Update()
    {
        if (laserCaster.isFiring == true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (lineRenderers.Count >= maxLines)
            {
                Destroy(lineRenderers[0].gameObject);
                lineRenderers.RemoveAt(0);
                Destroy(edgeColliders[0].gameObject);
                edgeColliders.RemoveAt(0);
            }
            // Create a new Line
            GameObject lineObj = new GameObject("Line");
            lineObj.tag = "Line";
            currentLineRenderer = lineObj.AddComponent<LineRenderer>();
            currentEdgeCollider = lineObj.AddComponent<EdgeCollider2D>();

            // Linerenderer settings
            currentLineRenderer.positionCount = 2;
            currentLineRenderer.useWorldSpace = true;
            currentLineRenderer.SetPosition(0, startPos);
            currentLineRenderer.material = lineMaterial; 
            currentLineRenderer.startColor = Color.white;
            currentLineRenderer.endColor = Color.white;
            currentLineRenderer.startWidth = 0.1f;
            currentLineRenderer.endWidth = 0.1f;

            lineRenderers.Add(currentLineRenderer);
            edgeColliders.Add(currentEdgeCollider);
        }
        if (Input.GetMouseButton(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentLineRenderer.SetPosition(1, endPos);
            SetEdgeCollider(currentLineRenderer, currentEdgeCollider);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentLineRenderer.SetPosition(1, endPos);
            SetEdgeCollider(currentLineRenderer, currentEdgeCollider);
        }
    }

    void SetEdgeCollider(LineRenderer lineRenderer, EdgeCollider2D edgeCollider)
    {
        List<Vector2> edges = new List<Vector2>();
        for (int point = 0; point < lineRenderer.positionCount; point++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }
        edgeCollider.SetPoints(edges);
    }
}