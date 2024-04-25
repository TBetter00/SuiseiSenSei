
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public Pacmon pacmon;
    public GameObject enemy;
    public GameObject bigEnemy;
    private Pacmon pacmonScript;
    private GameObject currentEnemy;
    private GameObject currentBigEnemy;
    //public PelletManager pellet;
    //public Transform pellets;

    public int score {get; private set;}
    public int lives {get; private set;}

    private void Start()
    {
        NewGame();
        pacmonScript = GetComponent<Pacmon>();
        CheckMon1();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown){
            NewGame();
        }
        //Debug.Log("Score: " + score);
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        /*
        foreach (Transform pellet in this.pellets) {
            pellet.gameObject.SetActive(true);
        }
        */
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

    public void SpawnEnemy()
    {

    }

    public void CheckMon1()
    {
        if (pacmonScript != null)
        {
            currentEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Pacmon script is null or stageEgg is false.");
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
