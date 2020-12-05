using UnityEngine;

/// <summary>
/// this script is attached on Controller to move Controller object by using mouse
/// </summary>
public class Movement : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        transform.position = camera.transform.position;
        transform.position += ray.direction;
        transform.rotation = Quaternion.LookRotation(ray.direction);
    }
}