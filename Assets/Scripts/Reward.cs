using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    Text scoretxt;
    public GameObject escudo;
    public GameObject media;
    public GameObject full;
    public int chance;
    public int score;

    public SpawnMaster spawnmaster;

    // Use this for initialization
    void Start()
    {
        scoretxt = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        spawnmaster = GameObject.Find("spawnmaster").GetComponent<SpawnMaster>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drop()
    {
        int n = random(1, 100);
        if (n <= chance)
        {
            int o = random(1, 100);
            if (o <= chance / 2)
            {
                dropItem(escudo);
            }
            else // Alguna vida
            {
                int m = random(0, 1);
                if (m == 0)
                {
                    dropItem(media);
                }
                else
                {
                    dropItem(full);
                }
            }
        }
    }

    int random(int min, int max)
    {
        return Mathf.FloorToInt(Random.Range(min, max));
    }

    void dropItem(GameObject item)
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }

    void OnDestroy()
    {
        int intscore = int.Parse(scoretxt.text);
        intscore += 100;
        scoretxt.text = intscore.ToString();

        if (intscore % 1000 == 0)
        {
            spawnmaster.level = intscore / 1000;
        }

        Drop();
    }

}
