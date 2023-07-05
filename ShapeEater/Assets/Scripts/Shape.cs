using UnityEngine;

public class Shape : MonoBehaviour
{
    public int type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pacman"))
        {
            Debug.Log("carpisti mi");
            ObjectPooling.Instance.SetPoolObject(gameObject, type);
        }
    }
}
