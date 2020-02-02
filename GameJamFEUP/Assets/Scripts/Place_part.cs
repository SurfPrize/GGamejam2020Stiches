using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_part : MonoBehaviour
{
    public bool isRight;
    public bool isArm;
    public List<BoxCollider2D> slots = new List<BoxCollider2D>();
    public Timer temporizador;

    //Application.platform == RuntimePlatform.Android;
    //RuntimePlatform.WindowsPlayer;
    // Start is called before the first frame update
    private void Start()
    {


        slots.Clear();
        foreach (GameObject este in GameObject.FindGameObjectsWithTag("Slots"))
        {
            if (este.GetComponent<BoxCollider2D>().enabled)
                slots.Add(este.GetComponent<BoxCollider2D>());
        }

        if (temporizador == null)
        {
            temporizador = FindObjectOfType<Timer>();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Drag_obj>() != null && other.GetComponent<Drag_obj>().dropped && gameObject.GetComponent<BoxCollider2D>().enabled)
        {
            other.gameObject.transform.position = gameObject.transform.position;
            other.gameObject.transform.rotation = gameObject.transform.rotation;
            other.gameObject.transform.parent = gameObject.transform;
            Drag_obj este = other.GetComponent<Drag_obj>();

            if (este.isRight == isRight && este.isArm == isArm)
            {
                FindObjectOfType<Score>().AddScore(temporizador.result * (temporizador.result / temporizador.time));
            }
            else
            {
                Debug.Log("Errado");
            }
            other.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            FindObjectOfType<Montagem>().Depart();
            check_enabled();
        }
    }

    private void check_enabled()
    {
        foreach (BoxCollider2D este in slots)
        {
            if (este.gameObject.transform.childCount == 0 && !este.enabled)
            {
                este.enabled = true;
            }
        }
    }
}
