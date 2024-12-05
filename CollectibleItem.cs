using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    public float rotationSpeed = 10f;
    void OnTriggerEnter(Collider other) {
        Debug.Log("item collected");
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime, 0);
    }
}
