using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour {
    int enemies;
    List<GameObject> numOfEnemies;
    public GameObject ghost;
    public GameObject walker;
    public Transform player;
    float timeHelper;
    public GameObject drop;
    //public Transform Enemy;
    //private Transform helper;
    int rngHelper;
    public Transform checkPoint;
    public GameObject bigBoss;

    public static EnemySpawner enemySpawner;

    bool enemyCanSpawn;
    bool bossSpawned;
    int enemiesKilled;


	// Use this for initialization
	void Start () {
        enemies = 7;
        numOfEnemies = new List<GameObject>();
        //helper = player;
        timeHelper = 0;
        rngHelper = 0;
        enemyCanSpawn = true;
        enemiesKilled = 0;
        bossSpawned = false;
        enemySpawner = this;

	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Joystick1Button4) || Time.time > timeHelper) && enemyCanSpawn)
        {
            //helper.position += new Vector3(10, Random.Range(0, 2));
            if(enemiesKilled > 7 )
            {
                enemyCanSpawn = false;
            }
            queueEnemySpawn();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            spawnBoss();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            stopSpawning();
        }
    }

    public void enemyDied(GameObject z)
    {
        //remove the enemy from the list
        numOfEnemies.Remove(z);
        enemiesKilled++;
        Destroy(z.gameObject);
    }

    public void enemyDiedToBullet(GameObject z)
    {
        //allow increasing rng chance of health drop
        if (Random.Range(0, 20) < rngHelper)
        {
            GameObject helper = Instantiate(drop, new Vector2(z.transform.position.x, z.transform.position.y), z.transform.rotation);
            rngHelper = 0; //rng reset
        }
        else
        {
            rngHelper += 1; //rng increase
        }
        enemyDied(z);
    }
    void queueEnemySpawn()
    {
        //forcing the spawner to wait in order to spawn enemies
        if (timeHelper <= Time.time)
        {

            spawnEnemy();
            timeHelper = Time.time + 1.0f;
        }
    }

    void spawnEnemy()
    {
        GameObject enemy;
        if (Random.Range(0,2) == 0)
        {
            enemy = Instantiate(ghost);
        }
        else
        {
            enemy = Instantiate(walker);
        }
        //create the new enemy in front of the gate
        enemy.transform.position = player.position + new Vector3(1, -2, 0);
        enemy.gameObject.GetComponent<enemyMovementController>().setRight(false);
        enemy.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "Players";
        numOfEnemies.Add(enemy);
    }

    public void spawnBoss()
    {
        GameObject theBoss = Instantiate(bigBoss);
        theBoss.transform.position = player.position + new Vector3(1, -2, 0);
        theBoss.gameObject.GetComponent<enemyMovementController>().setRight(false);
        theBoss.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "Players";
        numOfEnemies.Add(theBoss);
        bossSpawned = true;
    }

    public void bossDied()
    {
        new WaitForSeconds(1);
        SceneManager.LoadScene("DemoVictory");
    }

    void stopSpawning()
    {
        enemyCanSpawn = !enemyCanSpawn;
    }
}
