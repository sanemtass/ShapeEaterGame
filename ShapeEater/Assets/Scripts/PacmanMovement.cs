using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float swipeLength = currentMousePosition.y - lastMousePosition.y;

            if (swipeLength > 0)
            {
                float newYPosition = transform.position.y + speed * Time.deltaTime;
                newYPosition = Mathf.Clamp(newYPosition, -3f, 3f);
                transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
            }
            else if (swipeLength < 0)
            {
                float newYPosition = transform.position.y - speed * Time.deltaTime;
                newYPosition = Mathf.Clamp(newYPosition, -3f, 3f);
                transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
            }

            lastMousePosition = currentMousePosition;
        }
    }
}
