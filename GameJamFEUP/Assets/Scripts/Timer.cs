using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time;
    private float countdown;
    public float result;
    public TextMeshProUGUI temporizador;
    public GameObject gameover_obj;
    public bool stop_timer;
    public bool run_timer;
    public GameObject options;
    public AudioClip click_sound;

    // Start is called before the first frame update
    private void Start()
    {
        if (time == 0)
        {
            time = 5;
        }
        countdown = time + Time.time;
        stop_timer = false;
        run_timer = false;
        gameover_obj.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!stop_timer && run_timer)
        {
            result = countdown - Time.time;
            temporizador.text = result.ToString("F2");
            if (result <= 0)
            {
                Game_Over();
                run_timer = false;
                gameover_obj.SetActive(true);
                FindObjectOfType<grab_scores>().Display();
            }
        }
        else
        {
            countdown = result + Time.time;
        }
    }

    public void Reset_timer()
    {
        countdown = time + Time.time;
        time = time * 0.8f;
        if (time < 2)
        {
            time = 2;
        }
    }

    public void Game_Over()
    {
        foreach (BoxCollider2D este in FindObjectsOfType<BoxCollider2D>())
        {
            este.enabled = false;
        }
        temporizador.text = "";
        if (FindObjectOfType<highscores>() != null)
            FindObjectOfType<highscores>().save_new(FindObjectOfType<Score>().score);


    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync("MainGame");
    }
    public void Stoptime()
    {
        GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().clip = click_sound;
        GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().Play();
        if (stop_timer)
        {
            foreach (Drag_obj este in FindObjectsOfType<Drag_obj>())
            {
                este.setinvis(true);
            }
            stop_timer = false;
            options.SetActive(false);
            
        }
        else
        {
            stop_timer = true;
            options.SetActive(true);
            FindObjectOfType<grab_scores>().Display();
            foreach (Drag_obj este in FindObjectsOfType<Drag_obj>())
            {
                este.setinvis(false);
            }
        }
    }

    public void Return2menu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
