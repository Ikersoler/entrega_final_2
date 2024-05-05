using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{

    [SerializeField] private GameObject GameOver;
    //[SerializeField] private GameObject menu;
    [SerializeField] private GameObject Pause;


    private gameManager gemu;

    [SerializeField] private Button GameOverRestart;
    [SerializeField] private Button GameOverMainMenu;

    [SerializeField] private Button Pausecontinue
        ;
    [SerializeField] private Button Pauserestart;

    [SerializeField] private TextMeshProUGUI NRondas;

    private SpawnManager spawn;

    [SerializeField] private Button rondas;

    [SerializeField] private TextMeshProUGUI record;

    [SerializeField] private GameObject panelRecord;

    private dataPersistans data;

    private void Start()
    {
        gemu = FindObjectOfType<gameManager>();
        spawn = FindObjectOfType<SpawnManager>();
        data = FindObjectOfType <dataPersistans>();

        //GameOverRestart.onClick.AddListener(() => { gemu.Restart(); });

        //Lvl1.onClick.AddListener(() => { gemu.StartGame(1); });
        //Lvl2.onClick.AddListener(() => { gemu.StartGame(2); });

        if (GameOver != null && Pause != null )
        {
            hidePanels();

        }
        if (panelRecord != null )
        {
            HideRecordPanel();
        }

       



    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0f;
            showPause();
        }
    }








    public void GameOverPanel()
    {
        GameOver.SetActive(true);
        NRondas.text = $"Has Aguantado {spawn.numeroDeRondas} rondas";
    }
    public void hidePanels()
    {
        GameOver.SetActive(false);
       
        Pause.SetActive(false);

    }

    public void showPanels()
    {
        
        GameOver.SetActive(false);
        Pause.SetActive(false);
        
    }

    public void hidePause()
    {
        Pause.SetActive(false);
    }

    public void showPause()
    {
        Pause.SetActive(true);
    }

    public void resume()
    {
        hidePause();
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void goToMainMenu()
    {
        data.SaveJSON();
        SceneManager.LoadScene(0);
        
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        
    }

    public void HideRecordPanel()
    {
        panelRecord.SetActive(false);
    }

    public void ShowRecordPanel()
    {
        panelRecord.SetActive(true);
    }

    public void actualizarRecordPanel()
    {
        data.Load();
        record.text = $"En la ultima partida {data.roundsText}";
    }
}
