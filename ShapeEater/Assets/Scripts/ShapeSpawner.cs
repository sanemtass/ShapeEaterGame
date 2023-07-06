using System.Collections;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public float spawnRate = 1f;

    void Start()
    {
        StartCoroutine(SpawnShapes());
    }

    IEnumerator SpawnShapes()
    {
        while (true)
        {
            int[] activeObjectTypes = MissionManager.Instance.GetActiveObjectTypes();

            foreach (int type in activeObjectTypes)
            {
                yield return new WaitForSeconds(spawnRate);

                GameObject shape = ObjectPooling.Instance.GetPoolObject(type);
                Vector2 spawnPosition = new Vector2(transform.position.x, Random.Range(-3f, 3f));
                shape.transform.position = spawnPosition;
                shape.transform.rotation = Quaternion.identity;
            }
        }
    }
}
