
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public Pacmon pacmon;
    public GameObject enemy;
    public GameObject bigEnemy;
    public GameObject pinky;
    public GameObject inky;
    private GameObject currentEnemy;
    private GameObject currentBigEnemy;
    private GameObject currentPinky;
    private GameObject currentInky;
    public GameObject deadParticle;
    private bool hasSpawned1 = false;
    private bool hasSpawned2 = false;
    private bool isSpawningMonsters = false;
    private bool hasSpawnedRepeat = false;
    private bool hasSpawned3 = false;
    private bool hasSpawnedMega = false;
    public int spawnAmountAfterDeath = 2;
    public Palette[] pellet;
    private List<GameObject> enemies = new List<GameObject>();
    public int initialEnemyCount = 1;
    public float Safetime;
    public bool Vulnerable = true;



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
            SpawnMon0();
    }

    private void Update()
    {
        if (this.lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
            NewGame();
        }
        setNewRound();
        CheckMon0();
        CheckMon1();
        CheckMon2();



        
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }
    private void setNewRound()
    {
        if (!StillSomePelletLeft())
        {
            NewRound();
        }
    }
    
    private bool StillSomePelletLeft()
    {
        for (int i = 0; i < pellet.Length; i++)
        {
            if (!pellet[i].isEaten)
            {
                return true;
            }
        }
        return false;
    }

    private void NewRound()
    {
        for(int i = 0;i< pellet.Length; i++)
        {
            pellet[i].isEaten = false;
            pellet[i].isPowerUp1 = false;
            pellet[i].IsPowerUp2 = false;
        }
        ResetState();
    }

    private void ResetState()
    {
<<<<<<< Updated upstream
        this.pacmon.ResetState();
        this.pacmon.GetComponent<SpriteRenderer>().enabled = true;
        this.pacmon.GetComponent<CircleCollider2D>().enabled = true;
=======
        for (int i = 0; i < this.enemy.Length; i++)
        {
            this.enemy[i].ResetState();
        }

        this.pacmon.ResetState();
>>>>>>> Stashed changes
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void GameOver()
    {

        this.pacmon.gameObject.SetActive(false);
    }

    public void ChangeLives(int newLives)
    {
        SetLives(newLives);
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void EnemyKilled(int point)
    {
        SetScore(this.score + point);
    }

    public void PacmonKilled()
    {
        Vulnerable = false;
        Instantiate(deadParticle, this.pacmon.gameObject.transform.position, Quaternion.identity);
        this.pacmon.GetComponent<SpriteRenderer>().enabled = false;
        this.pacmon.GetComponent<CircleCollider2D>().enabled = false;
        SetLives(this.lives - 1);
        Debug.Log("pacmon killed");

        if (this.lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        } else{
            GameOver();
        }
        StartCoroutine(CoolDown());
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

    public void SpawnMon0()
    {
        currentPinky = Instantiate(pinky, spawnPoint.position, spawnPoint.rotation);
        currentInky = Instantiate(inky, spawnPoint.position, spawnPoint.rotation);
    }

    public void CheckMon0()
    {
        if (currentPinky == null)
        { 
            currentPinky = Instantiate(pinky, spawnPoint.position, spawnPoint.rotation);
        }
        if (currentInky == null)
        { 
            currentInky = Instantiate(inky, spawnPoint.position, spawnPoint.rotation);
        }

    }

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

        currentEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

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

        currentBigEnemy = Instantiate(bigEnemy, spawnPoint.position, spawnPoint.rotation);

    }



    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(Safetime);
        Vulnerable = true;
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
