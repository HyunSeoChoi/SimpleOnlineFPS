using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject spawnPoint;
    public int numbetOfEnemies;

    [HideInInspector]
    public List<csSpawnPoint> enemySpawnPoints;

	// Use this for initialization
	void Start () {
	    for(int i=0; i<numbetOfEnemies; i++)
        {
            var spawnPosition = new Vector3(Random.Range(-8f, 8f), 0f, Random.Range(-8f, 8f));
            var spawnRotation = Quaternion.Euler(0f, Random.Range(0, 180f), 0f);

            csSpawnPoint enemySpawnPoint = (Instantiate(spawnPoint, spawnPosition, spawnRotation) as GameObject).GetComponent<csSpawnPoint>();
            enemySpawnPoints.Add(enemySpawnPoint);
        }	
	}

    public void SpawnEnemies(/* networking */)
    {
        int i = 0;

        foreach(csSpawnPoint sp in enemySpawnPoints)
        {
            Vector3 position = sp.transform.position;
            Quaternion rotation = sp.transform.rotation;
            GameObject newEnemy = Instantiate(enemy, position, rotation) as GameObject;

            newEnemy.name = i+"";
            i++;

            csPlayerController pc = newEnemy.GetComponent<csPlayerController>();
            csHealth h = newEnemy.GetComponent<csHealth>();

            h.currentHealth = 100;
            h.OnChangeHealth();

            h.isEnemy = true;
            i++;
        }
    }
}
