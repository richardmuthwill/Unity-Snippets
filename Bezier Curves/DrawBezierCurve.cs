using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class DrawBezierCurve : MonoBehaviour
{
    public Transform[] controlPoints;
    public LineRenderer lineRenderer;
    public Transform startCurve, endCurve;

    private int curveCount = 0;
    private int layerOrder = 0;
    private int SEGMENT_COUNT = 50;

    [SerializeField] private int startSmooth = 15;
    [SerializeField] private int endSmooth = 10;

    void Start()
    {
        if (!lineRenderer)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        lineRenderer.sortingLayerID = layerOrder;
        curveCount = (int)controlPoints.Length / 3;
    }

    void Update()
    {
        controlPoints[0 + 1].position = Vector3.Lerp(controlPoints[0 + 1].position, startCurve.position, startSmooth * Time.deltaTime);
        controlPoints[(controlPoints.Length - 1) - 1].position = Vector3.Lerp(controlPoints[(controlPoints.Length - 1) - 1].position, endCurve.position, endSmooth * Time.deltaTime);

        DrawCurve();
    }

    void DrawCurve()
    {
        for (int j = 0; j < curveCount; j++)
        {
            for (int i = 1; i <= SEGMENT_COUNT; i++)
            {
                float t = i / (float)SEGMENT_COUNT;
                int nodeIndex = j * 3;
                Vector3 pixel = CalculateCubicBezierPoint(t, controlPoints[nodeIndex].position, controlPoints[nodeIndex + 1].position, controlPoints[nodeIndex + 2].position, controlPoints[nodeIndex + 3].position);
                lineRenderer.positionCount = ((j * SEGMENT_COUNT) + i);
                lineRenderer.SetPosition((j * SEGMENT_COUNT) + (i - 1), pixel);
            }
        }
    }

    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }
}