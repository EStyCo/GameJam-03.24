using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float moveSpeed = 2f;

    void Update()
    {
        var mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}
