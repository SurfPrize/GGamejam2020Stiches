using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montagem : MonoBehaviour
{
    private bool arriving;
    private bool departing;
    public float speed_org;
    private float speed;
    public GameObject prefab;
    public Timer temporizador;
    public AudioClip carro;

    // Start is called before the first frame update
    private void Start()
    {
        arriving = true;
        departing = false;
        if (speed_org == 0)
        {
            speed_org = 1;
        }
        speed = speed_org;
        if (temporizador == null)
        {
            temporizador = FindObjectOfType<Timer>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (arriving&&!temporizador.stop_timer)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y), Time.deltaTime * speed);
            speed = speed * 1.05f;
            GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().clip = carro;
            if (!GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().isPlaying)
                GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().Play();
            if (transform.position.y - Camera.main.transform.position.y < 0.05f)
            {
                transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
                arriving = false;
                temporizador.run_timer = true;
                temporizador.Reset_timer();
                speed = speed_org;
                GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().Stop();
            }
        }
        else if (departing&&!temporizador.stop_timer)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(0, -20), Time.deltaTime * speed);
            GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().clip = carro;
            if(!GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().isPlaying)
            GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().Play();
            if (transform.position.y + 20 < 1.5f)
            {
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().Stop();
                Instantiate(prefab, new Vector3(0, 30, 0), Quaternion.identity);
            }
        }
    }

    public void Depart()
    {
        
        if (GameObject.FindGameObjectWithTag("Mesa_Membros").transform.childCount == 0)
        {
            departing = true;
            temporizador.run_timer = false;
        }
    }
}
