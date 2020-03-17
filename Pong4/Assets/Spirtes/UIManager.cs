using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    
    [SerializeField] private TextMeshProUGUI player1Score;
    [SerializeField] private TextMeshProUGUI player2Score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);

    }
    public void UpdatePlayer1Score(int score)
    {
        player1Score.text = score.ToString();
    }
    public void UpdatePlayer2Score(int score)
    {
        player2Score.text = score.ToString();
    }
    private void Update()
    {
      
    }
}
