
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy[] enemy;
    public Pacmon pacmon;
    //public PelletManager pellet;
    //public Transform pellets;

    public int score {get; private set;}
    public int lives {get; private set;}

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown){
            NewGame();
        }
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
        for (int i = 0; i < this.enemy.Length; i++)
            {
            this.enemy[i].gameObject.SetActive(true);
        }

        this.pacmon.gameObject.SetActive(true);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void GameOver()
    {
        for (int i = 0; i < this.enemy.Length; i++){
            this.enemy[i].gameObject.SetActive(false);
        }

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
}
