using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkerActivate : MonoBehaviour
{
    public void on() {
        gameObject.SetActive(true);
    }
    
    public void off() {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        off();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
