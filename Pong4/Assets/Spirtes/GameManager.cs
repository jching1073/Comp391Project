using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{//singleton makes sure only one survives
    public static GameManager Instance = null;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    
    [SerializeField] private GameObject ball;


    private int player1Score = 0;
    private int player2Score = 0;

    private Ball ballScript;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);

        ballScript = ball.GetComponent<Ball>();
    }

   
    public void Score(GameObject player)
    {
        if (player == player1)
        {
            player2Score++;
            UIManager.Instance.UpdatePlayer2Score(player2Score);
        }else
        {
            player1Score++;
            UIManager.Instance.UpdatePlayer1Score(player1Score);

        }
        if (player1Score >= 3)
        {
            SceneManager.LoadScene(2);
        }
        if(player2Score >= 3)
        {
            SceneManager.LoadScene(3);

        }
        ResetBall();
        
    }
    private void ResetBall()
    {
        
        ballScript.ResetBall();
    }
}
