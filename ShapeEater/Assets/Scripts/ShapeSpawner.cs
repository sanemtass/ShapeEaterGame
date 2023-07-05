using System.Collections;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public float spawnRate = 2f;

    void Start()
    {
        StartCoroutine(SpawnShapes());
    }

    IEnumerator SpawnShapes()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            // Burada bir GameObject'yi rastgele seçip, rastgele bir yükseklikte spawn ediyoruz.
            int shapeType = Random.Range(0, ObjectPooling.Instance.pools.Length);
            GameObject shape = ObjectPooling.Instance.GetPoolObject(shapeType);
            Vector2 spawnPosition = new Vector2(transform.position.x, Random.Range(-5f, 5f)); // Not: -5 ve 5, sahnenizin boyutlarına göre ayarlanmalıdır.
            shape.transform.position = spawnPosition;
            shape.transform.rotation = Quaternion.identity;
        }
    }
}
