using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Mouse sol tuşuna basıldığında başlangıç pozisyonunu kaydet
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        // Mouse sol tuşu basılı tutulduğu sürece, hareket et
        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float swipeLength = currentMousePosition.y - lastMousePosition.y;

            if (swipeLength > 0)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else if (swipeLength < 0)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }

            // Son fare pozisyonunu güncelle
            lastMousePosition = currentMousePosition;
        }
    }
}
