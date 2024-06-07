using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject enemy;
    public float enemyCount = 10.0f;
    public float enemyTimer = 2.0f;
    private Image health1;
    private Image health2;
    private Image health3;
    private Image health4;
    private GameManager instance = null;
    private Player playerScript;
    public Vector3 spawnValue;
    public float waveTimer = 2.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = Resources.Load<GameObject>("Prefabs/Enemy");
        health1 = GameObject.Find("Health 1").GetComponent<Image>();
        health2 = GameObject.Find("Health 2").GetComponent<Image>();
        health3 = GameObject.Find("Health 3").GetComponent<Image>();
        health4 = GameObject.Find("Health 4").GetComponent<Image>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();

        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        Health();
    }

    private IEnumerator SpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyTimer);
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(enemyTimer);
            }
            yield return new WaitForSeconds(waveTimer);
        }
    }

    private void Health()
    {
        if(playerScript.health == 100.0f)
        {
            health1.color = Color.white;
            health2.color = Color.white;
            health3.color = Color.white;
            health4.color = Color.white;
        }
        else if (playerScript.health == 75.0f)
        {
            health1.color = Color.white;
            health2.color = Color.white;
            health3.color = Color.white;
            health4.color = Color.red;
        }
        else if (playerScript.health == 50.0f)
        {
            health1.color = Color.white;
            health2.color = Color.white;
            health3.color = Color.red;
            health4.color = Color.red;
        }
        else if (playerScript.health == 25.0f)
        {
            health1.color = Color.white;
            health2.color = Color.red;
            health3.color = Color.red;
            health4.color = Color.red;
        }
        else if (playerScript.health == 0.0f)
        {
            health1.color = Color.red;
            health2.color = Color.red;
            health3.color = Color.red;
            health4.color = Color.red;
        }
    }
}
