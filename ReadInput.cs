using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    
    [SerializeField] InputField inputField;
    
    
    // Start is called before the first frame update

    public void validateInput() {
        string input = inputField.text;
        
        Debug.Log(input);
    }

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
