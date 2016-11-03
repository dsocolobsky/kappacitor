using UnityEngine;
using UnityEngine.UI;

public class SpawnMaster : MonoBehaviour {

    public int level = 1;
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

        if (numberEnemies < level)
        {
            GameObject s = spawners[Random.Range(0, spawners.Length)];
            s.GetComponent<Spawner>().Spawn(spawningEnemies[Random.Range(0, spawningEnemies.Length)]);
        }
    }
}
