using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;

    public GameObject pauseGameMenu;

    public GameDataScript gameData;

    public AudioSource audioSource;
    public AudioClip pointSound;

    public Sprite audioOn;
    public Sprite audioOff;
    public GameObject buttonAudio;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = slider.value;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }    
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadMenu()
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame()
    {
        Cursor.visible = false;
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NewGame()
    {
        gameData.Reset();
        Cursor.visible = false;
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
    }

    void Start()
    {
        Cursor.visible = true;
    }
}
