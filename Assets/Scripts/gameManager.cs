using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private UiManager uiMan;

    private PlayerController playerControl;

    private dataPersistans data;

   

    public void Start()
    {
       
        uiMan.showPanels();
        Time.timeScale = 0f;
        data = FindObjectOfType <dataPersistans> ();
        Debug.Log(data == null);

    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        
    }

    public void resume()
    {
        uiMan.hidePause();
        Time.timeScale = 1f;

    }

    private void Awake()
    {
        uiMan = FindObjectOfType<UiManager>();
        uiMan.hidePanels();
        playerControl = FindObjectOfType<PlayerController>();

    }

    public void StartGame()
    {
        uiMan.hidePanels();

        Time.timeScale = 1f;

       
    }


    


}