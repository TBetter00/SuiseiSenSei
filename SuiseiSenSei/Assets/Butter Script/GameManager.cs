
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public Pacmon pacmon;
    public GameObject enemy;
    public GameObject bigEnemy;
    private GameObject currentEnemy;
    private GameObject currentBigEnemy;
    private bool hasSpawned1 = false;
    private bool hasSpawned2 = false;
    private bool isSpawningMonsters = false;
    private bool hasSpawnedRepeat = false;
    public Palette[] pellet;
    //public PelletManager pellet;
    //public Transform pellets;

    public int score {get; private set;}
    public int lives {get; private set;}

    private void Start()
    {
        pellet = FindObjectsOfType<Palette>();
        NewGame();
        GameObject pacmonGameObject = GameObject.Find("Pukkermon");
        if (pacmonGameObject != null)
            {
                pacmon = pacmonGameObject.GetComponent<Pacmon>();
            }
        else
            {
                Debug.LogWarning("Pacmon GameObject not found.");
            }
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown){
            NewGame();
        }
        CheckMon1();
        CheckMon2();
        StartCoroutine(SpawnMonRepeatly());


    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        for(int i = 0;i< pellet.Length; i++)
        {
            pellet[i].isEaten = false;
        }
        ResetState();
    }

    private void ResetState()
    {
        this.pacmon.ResetState();
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void GameOver()
    {

        this.pacmon.gameObject.SetActive(false);
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void EnemyKilled(Enemy enemy)
    {
        SetScore(this.score + enemy.points);
    }

    public void PacmonKilled()
    {
        this.pacmon.gameObject.SetActive(false);
        SetLives(this.lives - 1);

        if (this.lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        } else{
            GameOver();
        }
    }

    public void PelletEat(int score)
    {
        //this.pellet.gameObject.SetActive(false);
        SetScore(this.score + score);
    }

    // public void PelletEaten(Pellet pellet)
    // {
    //     pellet.gameObject.SetActive(false);
    //     SetScore(this.score + pellet.point);
    // }

    // in stage 1 spawn first monster and when that monster die it will spawn 1 monster
    public void CheckMon1()
    {
        if (pacmon.stage1 && !hasSpawned1)
        {   
            SpawnMon1();
            hasSpawned1 = true;
        }
        if (hasSpawned1 && currentEnemy == null)
        {
            SpawnMon1();
        }

    }

    public void SpawnMon1()
    {
        if (pacmon.stage1)
        {
            currentEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }


    public void CheckMon2()
    {
        if (pacmon.stage2 && !hasSpawned2)
        {   
            SpawnMon2();
            hasSpawned2 = true;
        }
        if (hasSpawned2 && currentBigEnemy == null)
        {
            SpawnMon2();
        }

    }

    public void SpawnMon2()
    {
        if (pacmon.stage2)
        {
            currentBigEnemy = Instantiate(bigEnemy, spawnPoint.position, spawnPoint.rotation);
        }
    }

    IEnumerator SpawnMonRepeatly()
    {
        
        if ((pacmon.stage2 || pacmon.stage3) && !hasSpawnedRepeat)
        {
            hasSpawnedRepeat = true;
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(5);
            hasSpawnedRepeat = false;
            

        }
        
    }



    /*
    public void PowerPellet(PowerPallet pellet)
    {
        PelletEaten(pellet);
    }

    private bool HasRemainingPellets()
    {
        foreach(Transform pellet in this.pellet)
        {

        }
    }
    */
}
