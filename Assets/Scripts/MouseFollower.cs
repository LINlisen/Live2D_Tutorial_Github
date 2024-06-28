using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool smoothFollow = true;
    [SerializeField] private float smoothSpeed = 5f;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (smoothFollow)
        {
            transform.position = Vector2.Lerp(transform.position, mousePosition, smoothSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = mousePosition;
        }
    }
}
