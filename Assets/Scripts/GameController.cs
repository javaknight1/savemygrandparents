using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text score;
    public Image grandmaX;
    public Image grandpaX;
    public GameObject gameOverPanel;
    public EnemySpawner spawner;
    public AudioSource audioSource;
    public float volume = 0.5f;

    bool grandpa;
    bool grandma;
    int kills;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Stop();
        audioSource.Play();

        grandpa = false;
        grandma = false;
        kills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + kills;
        grandmaX.gameObject.SetActive(grandma);
        grandpaX.gameObject.SetActive(grandpa);

        if (grandma && grandpa)
        {
            audioSource.Stop();
            gameOverPanel.SetActive(true);
            spawner.EndSpawning();
        }
    }

    public void killGrandma()
    {
        grandma = true;
    }

    public void killGrandpa()
    {
        grandpa = true;
    }

    public void addScore()
    {
        addScores(1);
    }

    public void addScores(int scores)
    {
        kills += scores;
    }
}
