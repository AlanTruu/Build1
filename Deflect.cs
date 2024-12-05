using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deflect : MonoBehaviour
{
    public bool deflecting;
    private Quaternion idle;
    private Quaternion deflectAngle;
    private bool attacking;
    // private float rotationSpeed = 80f;
    private float blockSpeed = 80f;
    public bool parry;
    private Coroutine rotationCo;
    private float parryWindow = 0.2f;
    private float parryTimer;
    private BoxCollider dynamicHBox;
    public int swingDamage = 20;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip bonkSound;
    
    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        attacking = false;
        parry = false;
        parryTimer = 0f;
        deflecting = false;
        idle = transform.localRotation;
        deflectAngle = Quaternion.Euler(0, 0, -50);
        dynamicHBox = GetComponent<BoxCollider>();
        dynamicHBox.enabled = false;
       
    }


    public void offBox() {
        dynamicHBox.enabled = false;
    }

    public void onBox() {
        dynamicHBox.enabled = true;
    }
    //using local rotation because bat's rotation is not aligned with world
    public void OnTriggerEnter(Collider other) {
        Life entityLife = other.GetComponent<Life>();
        Player p = other.GetComponent<Player>();
        if (entityLife && !p) {
            entityLife.damage(swingDamage);
            Debug.Log("Swung");
            soundSource.PlayOneShot(bonkSound);
        }
    }
    
    private IEnumerator rotateTo(Quaternion target, float rotationSpeed) {
        while (Quaternion.Angle(transform.localRotation, target) > 0.1f) {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, rotationSpeed*Time.deltaTime);
            yield return null;
        }
        transform.localRotation = target;
        
    }

    public void resetAttack() {
        attacking = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !deflecting) {
            if (rotationCo != null)
            {
                StopCoroutine(rotationCo); 
            }
            rotationCo = StartCoroutine(rotateTo(deflectAngle, blockSpeed)); 
            deflecting = true;
            parryTimer = parryWindow;
        }
        else if (!Input.GetMouseButton(1)) {
            if (rotationCo != null)
            {
                StopCoroutine(rotationCo); 
            }
            rotationCo = StartCoroutine(rotateTo(idle, blockSpeed)); 
            deflecting = false;
            
        }
        if (Input.GetMouseButton(0) && !deflecting && !attacking) {
            onBox();
            attacking = true;
            transform.Rotate(0,-80,0);
            
            
        }
        else if (Input.GetMouseButtonUp(0) && attacking) {
            offBox();
            transform.Rotate(0, 80, 0);
            Invoke(nameof(resetAttack), 2f);

        }

        if (parryTimer > 0) {
            parryTimer -= Time.deltaTime;
            float angleDiff = Quaternion.Angle(transform.localRotation, deflectAngle);
            parry = angleDiff < 5f;
        }
        else {
            parry = false;
        }
    }
    
}
