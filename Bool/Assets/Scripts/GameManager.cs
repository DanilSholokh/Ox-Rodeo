using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Button buttonStart;
    [SerializeField] private Bullconomica bullconomica;

    private bool isPaused;
    [SerializeField] private GameObject pausePanel;

    private LevelBeginer levelBeginer;
    public static GameManager Instance { get; private set; }
    public bool IsPaused { get => isPaused;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        levelBeginer = GetComponent<LevelBeginer>(); 

    }


    public void looseGame()
    {

        levelBeginer.lastFrameStartLevel();
        buttonStart.gameObject.SetActive(true);

    }

    public void saveDelet()
    {
        PlayerPrefs.DeleteAll();
    }

    public void TogglePause()
    {
        isPaused = !IsPaused;

        if (IsPaused)
        {
            Time.timeScale = 0f; // Останавливаем время
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f; // Возобновляем время
            pausePanel.SetActive(false);
        }
    }

    public void QuitGame()
    {

        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    
    }

}
