using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;

    public List<Vector2> Points = new List<Vector2>
    {
        new Vector2(-3, 5),
        new Vector2(0, 5),
        new Vector2(3, 5)
    };

    void Start()
    {
        // StartCoroutine(SpawnRandom());
    }

    public void SpawnEnemy(GameObject prefab, Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }

    public IEnumerator SpawnRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            SpawnEnemy(
                EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)],
                Points[Random.Range(0, Points.Count)]
            );
        }
    }
}