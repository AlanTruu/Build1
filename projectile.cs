using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float projectileSpeed = 4f;
    public int damage = 1;
    public bool deflected;
    // Start is called before the first frame update
    public void OnTriggerEnter (Collider collider) {
        Deflect deflect = collider.GetComponent<Deflect>();
        if (deflect) {
            if (deflect.parry == true) {
                deflected = true;
            }
        }
        else if (collider.GetComponent<Life>()) {
            Life life = collider.GetComponent<Life>();
            life.damage(damage);
            Debug.Log("damage done");
            Destroy(this.gameObject);
        }
        else if (collider) {Destroy(this.gameObject);}
        
    }
    void Start()
    {
        deflected = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, projectileSpeed*Time.deltaTime);
        if (deflected == true) {
            projectileSpeed *= -1f;
            deflected = false;
        }
    
    }
}
