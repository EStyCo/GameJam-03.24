using UnityEngine;

public class CameraFollowUI : MonoBehaviour
{
    public RectTransform target;
    public Vector3 offset;
    public float smoothSpeed;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
