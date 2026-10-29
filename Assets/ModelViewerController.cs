
using UnityEngine;

public class ModelViewerController : MonoBehaviour
{
    public float rotationSpeed = 120f;
    public float zoomSpeed = 0.5f;
    public float minZoom = 2f;
    public float maxZoom = 8f;

    private Camera viewCamera;
    private Vector3 lastMousePosition;

    void Start()
    {
        viewCamera = Camera.main;
    }

    void Update()
    {
        if (viewCamera == null) return;

        if (Input.GetMouseButtonDown(0))
            lastMousePosition = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            transform.Rotate(Vector3.up,
                -delta.x * rotationSpeed * Time.deltaTime,
                Space.World);

            transform.Rotate(Vector3.right,
                delta.y * rotationSpeed * Time.deltaTime,
                Space.World);

            lastMousePosition = Input.mousePosition;
        }

        float scroll = Input.mouseScrollDelta.y;

        if (Mathf.Abs(scroll) > 0.01f)
        {
            viewCamera.transform.position +=
                viewCamera.transform.forward * scroll * zoomSpeed;

            float distance = Vector3.Distance(
                viewCamera.transform.position, transform.position);

            if (distance < minZoom || distance > maxZoom)
            {
                viewCamera.transform.position =
                    transform.position -
                    viewCamera.transform.forward *
                    Mathf.Clamp(distance, minZoom, maxZoom);
            }
        }
    }
}
