using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemEquipper : MonoBehaviour
{
    [SerializeField] private GameObject baseballBatPrefab;
    [SerializeField] private GameObject waterGunPrefab;
    [SerializeField] public ParticleSystem waterGunFX;
    public ParticleSystem jet;
    private GameObject currentEquipped;
    public WhatIsEquipped equipment;

    public enum WhatIsEquipped {
        nothing = 0, waterGun = 1, bat = 2
    }
    // Start is called before the first frame update
    void Start()
    {
        equipment = WhatIsEquipped.nothing;
        jet = Instantiate(waterGunFX, transform) as ParticleSystem;
        jet.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) {
            if (currentEquipped != null) {
                Destroy(currentEquipped);
            }
            currentEquipped = Instantiate(waterGunPrefab, transform) as GameObject;
            currentEquipped.transform.position = transform.position;
            currentEquipped.transform.position = transform.TransformPoint(Vector3.right*(0.2f) + Vector3.back*(0.3f));
            equipment = WhatIsEquipped.waterGun;
            
        }
        else if (Input.GetKeyDown("2")) {
            if (currentEquipped != null) {
                Destroy(currentEquipped);
            }
            currentEquipped = Instantiate(baseballBatPrefab, transform) as GameObject;
            currentEquipped.transform.position = transform.position;
            equipment = WhatIsEquipped.bat;
        }
        else if (Input.GetKeyDown("3")) {
            if (currentEquipped != null) {
                Destroy(currentEquipped);
            }
            equipment = WhatIsEquipped.nothing;
        }
    }
}
