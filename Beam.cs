using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Beam : MonoBehaviour
{
    private Camera _camera;
    public int damage = 10;
    public float fireRate = 0.2f;
    private bool alreadyAttacked;
    private ParticleSystem waterJet;
    private ItemEquipper item;
    [SerializeField] HitMarkerActivate hitMarker;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip mlgSound;
    [SerializeField] private AudioClip water;
    // Start is called before the first frame update
    
    void Start()
    {
        alreadyAttacked = false;
        item = GetComponentInChildren<ItemEquipper>();
        _camera = GetComponent<Camera>();
        waterJet = item.jet;
        if (waterJet != null && item != null) {
            Debug.Log("nothing is empty probably");
        }
    }

    public void resetAttack() {
        alreadyAttacked = false;
    }
    public void jetOn() {
        waterJet.gameObject.SetActive(true);
        waterJet.transform.position = transform.TransformPoint(Vector3.right*(0.44f) + Vector3.forward*(1.3f) + Vector3.down*(0.2f));
    }
    public void jetOff() {
        waterJet.gameObject.SetActive(false);
    }
    
    private IEnumerator fireRoutine() {
        jetOn();
        yield return new WaitForSeconds(0.2f);
        jetOff();
    }


    private void resetMarker() {
        hitMarker.off();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponentInChildren<ItemEquipper>().equipment == ItemEquipper.WhatIsEquipped.waterGun && !alreadyAttacked) {
            Debug.Log("Is this working");
            StartCoroutine(fireRoutine());
            alreadyAttacked = true;
            soundSource.PlayOneShot(water);
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<Life>()) {
                    soundSource.PlayOneShot(mlgSound);
                    hitMarker.on();
                    Invoke(nameof(resetMarker), 0.2f);
                    hitObject.GetComponent<Life>().damage(damage);
                }
            }
            Invoke(nameof(resetAttack), fireRate);
        }
    }
}
