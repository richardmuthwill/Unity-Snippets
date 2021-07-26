using UnityEngine;

public class CalculateBeizerCurvePoints : MonoBehaviour
{
    [SerializeField] Transform start, end, p1, p2, startOut, endOut;

    QuadBez curve;
    CubicBez curve2;

    // Start is called before the first frame update
    void Start()
    {
        // curve = new QuadBez(start.position, end.position, p1.position);
        curve2 = new CubicBez(start.position, end.position, p1.position, p2.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newP1 = new Vector3(start.position.x + (end.position.x - start.position.x) / 3, start.position.y + (end.position.y - start.position.y) / 3, start.position.z + (end.position.z - start.position.z) / 3);
        // Vector3 newP2 = new Vector3(end.position.x + (start.position.x - end.position.x) / 3, end.position.y + (start.position.y - end.position.y) / 3, end.position.z + (start.position.z - end.position.z) / 3);

        p1.position = Vector3.Lerp(p1.position, startOut.position, 15 * Time.deltaTime);
        p2.position = Vector3.Lerp(p2.position, endOut.position, 3 * Time.deltaTime);

        // curve = new QuadBez(start.position, end.position, p1.position);
        curve2 = new CubicBez(start.position, end.position, p1.position, p2.position);
    }
    
	void OnDrawGizmos()
	{
        Vector3 newP1 = new Vector3(start.position.x + (end.position.x - start.position.x) / 3, start.position.y + (end.position.y - start.position.y) / 3, start.position.z + (end.position.z - start.position.z) / 3);

        p1.position = Vector3.Lerp(p1.position, startOut.position, 15 * Time.deltaTime);
        p2.position = Vector3.Lerp(p2.position, endOut.position, 3 * Time.deltaTime);

        curve2 = new CubicBez(start.position, end.position, p1.position, p2.position);
        curve2.GizmoDraw(1f);
    }
}
