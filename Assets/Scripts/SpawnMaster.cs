using UnityEngine;
using System.Collections;

public class SpawnMaster : MonoBehaviour {

    public int enemies;
    int numberEnemies;
    GameObject[] spawners;

    public GameObject[] spawningEnemies;

    // Use this for initialization
    void Start () {
        spawners = GameObject.FindGameObjectsWithTag("spawner");
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] enemyArray;
        enemyArray = GameObject.FindGameObjectsWithTag("enemy");
        numberEnemies = enemyArray.Length;

        if (numberEnemies < 1)
        {
            GameObject s;
            for (int i = 0; i < 4; i++)
            {
                s = spawners[i];
                s.GetComponent<Spawner>().Spawn(spawningEnemies[Random.Range(0, spawningEnemies.Length)]);
            }
        }
    }

    bool insideCamera(Vector3 transform)
    {
        return (Camera.main.WorldToViewportPoint(transform).x >= 0 &&
            Camera.main.WorldToViewportPoint(transform).x <= 1) &&
            (Camera.main.WorldToViewportPoint(transform).y >= 0 &&
            Camera.main.WorldToViewportPoint(transform).y <= 1);
    }
}
