using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject startScene;
    public void Startgame()
    {
        startScene.SetActive(false);
        SceneManager.LoadScene("LoadingScene");
    }
    
}
