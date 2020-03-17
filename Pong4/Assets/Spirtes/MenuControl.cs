using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public Button Play_Botton;
    public Button Quit_Botton;
    // Start is called before the first frame update
    
    public void Play_Game ()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit_Game()
    {
        Application.Quit();
    }
}
