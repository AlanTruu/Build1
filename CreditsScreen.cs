using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScreen : MonoBehaviour
{
    public void on() {
        this.gameObject.SetActive(true);
    }
    
    public void off() {
        this.gameObject.SetActive(false);
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
