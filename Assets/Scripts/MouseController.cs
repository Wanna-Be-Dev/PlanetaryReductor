using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [Header("Mouse settings")]
    [SerializeField, Tooltip("sensitivity for mouse")] private float _mouseSensitivity = 1.0f;

    private float rotationY;
    private float rotationX;

    [Header("Object settings")]
    [SerializeField, Tooltip("Object around which the camera rotates")] private Transform target;
    [SerializeField] private float distance = 0.7f;
    [SerializeField] private float CameraOffsetX = 0f;

    private Vector3 currentRotation;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] float smoothtime = 0.2f;
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 mouse = new Vector2(Input.GetAxis("Mouse X") * _mouseSensitivity, Input.GetAxis("Mouse Y") * _mouseSensitivity);

            rotationY += mouse.x;
            rotationX += mouse.y;

            Vector3 nextRoatation = new Vector3(rotationX, rotationY);
            currentRotation = Vector3.SmoothDamp(currentRotation, nextRoatation, ref velocity, smoothtime);

            transform.localEulerAngles = currentRotation;
           
        }
        transform.position = target.position - transform.forward * distance;
        transform.position += new Vector3(CameraOffsetX, 0, 0);
    }

    public void SetNewPivot(GameObject part, float newDistance,float newOffset)
    {
        target = part.transform;
        StartCoroutine(ZoomIn(newDistance, newOffset));
    }

    private IEnumerator ZoomIn(float newdistance, float newOffset)
    {
        float timer = 0;
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            CameraOffsetX = Mathf.Lerp(CameraOffsetX, newOffset, 0.3f);
            distance = Mathf.Lerp(distance, newdistance, 0.3f);
            yield return null;
        }
        distance = newdistance;// to make sure the distance is the rright one (no decimals)
        CameraOffsetX = newOffset;
    }
}
