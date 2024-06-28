using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float minZoom = 0.1f;
    public float maxZoom = 100f;

    private Vector3 dragOffset;
    private Camera mainCamera;
    private bool isMouseOver = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isMouseOver)
        {
            // 滾輪縮放
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                Vector3 scale = transform.localScale;
                scale += Vector3.one * scroll * zoomSpeed;
                scale.x = Mathf.Clamp(scale.x, minZoom, maxZoom);
                scale.y = Mathf.Clamp(scale.y, minZoom, maxZoom);
                transform.localScale = scale;
            }
        }
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + dragOffset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // 保持z軸不變
        return mousePosition;
    }
}