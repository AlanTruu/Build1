using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsPopUp : MonoBehaviour
{
    [SerializeField] private InputField input;
    public void open() {
        gameObject.SetActive(true);
    }
    
    public void close() {
        gameObject.SetActive(false);
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
