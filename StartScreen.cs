using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public void on() {
        this.gameObject.SetActive(true);
    }
    public void off() {
        this.gameObject.SetActive(false);
    }

    public void startB() {
        SceneManager.LoadScene("SampleScene");
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
