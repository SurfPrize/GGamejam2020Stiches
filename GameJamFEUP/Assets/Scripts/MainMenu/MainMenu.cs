using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Inicial_Buttons;
    public GameObject Options_Buttons;
    public string CenaMainGame;
    public AudioSource click_sound;
    public void PlayGame() 
    {
        SceneManager.LoadSceneAsync(CenaMainGame);
        click_sound.Play();
    }
    public void ExitGame() 
    {
        Application.Quit();    
    }
    public void OpenOptions()
    {
        Inicial_Buttons.SetActive(false);
        Options_Buttons.SetActive(true);
        click_sound.Play();
    }
    public void CloseOptions()
    {
        Inicial_Buttons.SetActive(true);
        Options_Buttons.SetActive(false);
        click_sound.Play();
    }
    public void Fullscreen(bool state)
    {
        Screen.fullScreen = state;
        click_sound.Play();
    }
}
