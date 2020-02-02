using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_obj : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public bool isRight;
    public bool isArm;
    public bool dropped;
    public AudioClip spitting;

    private void OnMouseDown()
    {
        if (!FindObjectOfType<Timer>().stop_timer)
        {
            dropped = false;
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    private void OnMouseDrag()
    {
        if (!FindObjectOfType<Timer>().stop_timer)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
        }
    }
    private void OnMouseUp()
    {
        if (!FindObjectOfType<Timer>().stop_timer)
        {
            dropped = true;
            GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().clip = spitting;
            GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>().Play();

        }

    }

    public void setinvis(bool state)
    {

        GetComponent<SpriteRenderer>().enabled = state;

    }

}
