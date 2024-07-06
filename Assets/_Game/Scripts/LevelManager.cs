using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private int lives = 10;

    private static LevelManager instance = null;
    private int TotalLives{ get; set; }
    private int CurrentWave{ get; set; }

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TotalLives = lives;
        CurrentWave = 1;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void ReduceLives(Enemy enemy)
    {
        TotalLives--;
        if (TotalLives <= 0)
        {
            TotalLives = 0;
            GameOver();
        }
    }

    private void GameOver()
    {

    }

    // private void OnEnable()
    // {
    //     // Enemy.OnEndReached? += ReduceLives;
    // }

    // private void OnDisable()
    // {
    //     Enemy.OnEndReached -= ReduceLives;
    // }    
}
