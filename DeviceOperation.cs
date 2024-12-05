using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperation : MonoBehaviour
{
    public float radius = 1.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider collider in hitColliders) {
                Vector3 direction = collider.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.5f) {
                    collider.SendMessage("operate", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
