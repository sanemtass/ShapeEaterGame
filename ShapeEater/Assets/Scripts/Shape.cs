using UnityEngine;

public class Shape : MonoBehaviour
{
    public int type;
    public string shapeName;
    public Sprite shapeSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pacman"))
        {
            ObjectPooling.Instance.SetPoolObject(gameObject);
        }
    }
}