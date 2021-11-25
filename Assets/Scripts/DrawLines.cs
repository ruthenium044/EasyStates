using UnityEngine;

public class DrawLines : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Vector2 lineSize;
    [SerializeField] private int vertexCount;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(material);
        lineRenderer.startWidth = lineSize.x;
        lineRenderer.endWidth = lineSize.y;
        lineRenderer.loop = true;
        DrawPolygon(vertexCount, 1, Vector3.zero);
    }
    
    void DrawPolygon(int vertexCount, float radius, Vector3 position)
    {
        lineRenderer.positionCount = vertexCount;
        float angle = 2 * Mathf.PI / vertexCount;

        for (int i = 0; i < vertexCount; i++)
        {
            Matrix4x4 rotationMatrix = new Matrix4x4(
                new Vector4(Mathf.Cos(angle * i), Mathf.Sin(angle * i), 0, 0),
                new Vector4(-1 * Mathf.Sin(angle * i), Mathf.Cos(angle * i), 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(0, 0, 0, 1));
            Vector3 initialRelativePosition = new Vector3(0, radius, 0);
            lineRenderer.SetPosition(i, position - rotationMatrix.MultiplyPoint(initialRelativePosition));
        }
    }
}
