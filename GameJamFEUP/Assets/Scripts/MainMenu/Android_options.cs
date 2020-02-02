using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Android_options : MonoBehaviour
{
    public List<GameObject> apagar = new List<GameObject>();
    public bool testar_android;
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android || testar_android)
        {
            foreach(GameObject este in apagar){
                Destroy(este);
            }
        }
        apagar.Clear();
    }
    
}
