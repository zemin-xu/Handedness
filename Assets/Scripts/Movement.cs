using UnityEngine;

/// <summary>
/// this script is attached on Controller to move Controller object by using mouse
/// </summary>
public class Movement : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float mouseMovementThreshold = 5.0f;

    [SerializeField]
    private float forwardSpeed = 0.1f;

    [SerializeField]
    private Navigation navigation;

    private Vector3 prevMousePos;

    public Vector3 offset;

    private void Update()
    {
        Vector3 currMousePos = Input.mousePosition;
        offset = currMousePos - prevMousePos;

        if (offset.magnitude > mouseMovementThreshold)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            // move in depth direction
            if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
            {
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    float step = forwardSpeed * Time.deltaTime; // calculate distance to move
                    if (offset.y > 0)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, step);
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.forward, step);
                    }
                }
                else
                {
                    transform.position = camera.transform.position;
                    transform.position += ray.direction;
                    transform.rotation = Quaternion.LookRotation(ray.direction);
                }
            }
        }
        prevMousePos = currMousePos;
    }
}