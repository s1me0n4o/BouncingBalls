using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 dragStartPoint;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    //seting the start point to be equal to the wordClickedPoint
    public void SetStartPoint (Vector3 wordPoint)
    {
        dragStartPoint = wordPoint;
        lineRenderer.SetPosition(0, dragStartPoint);
    }

    public void SetEndPoint(Vector3 wordPoint)
    {
        Vector3 endPointOffset = wordPoint - dragStartPoint;
        Vector3 endPoint = this.transform.position + endPointOffset;

        lineRenderer.SetPosition(1, endPoint);
    }
}
