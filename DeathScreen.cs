using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public void open() {
        gameObject.SetActive(true);
    }

    public void close() {
        gameObject.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
