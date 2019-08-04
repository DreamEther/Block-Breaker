using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameSession : MonoBehaviour
{
    // config parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;  // just using 1 as a starting point
    [SerializeField] int pointsPerBlockDestroyed = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables 
    [SerializeField] int currentScore = 0;
    Block timesHit;


    // Start is called before the first frame update


    private void Awake()
    {
         
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
   
         else
        {
            DontDestroyOnLoad(gameObject);
        }      
    }
    private void Start()
    {
         scoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void addToScore()
    {
          currentScore = currentScore + pointsPerBlockDestroyed;
          scoreText.text = currentScore.ToString();
    }

    public void resetScore()
    {
        Destroy(gameObject); //small g because we're talking about this particular instance of gameObject
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;    //returning true of false
    }
}
