using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxHealth;
    public int health = 5;
    public int minH = 0;
    private Player p;
    private CharacterController controller;
    private TyphlosionAI typhlosion;
    // Start is called before the first frame update
    public void damage(int dmg) {
        health -= dmg;
    }
    void heal(int healthBonus) {
        health += healthBonus;
    }
    void fullHeal() {
        health = maxHealth;
    }

    private IEnumerator die() {
        transform.Rotate(65, 0, 0);
        typhlosion.agent.SetDestination(typhlosion.gameObject.transform.position);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
    void Start()
    {
        health = maxHealth;
        p = GetComponent<Player>();
        controller = GetComponent<CharacterController>();
        typhlosion = GetComponent<TyphlosionAI>();
        health = Mathf.Clamp(health, 0, maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && p) {
            fullHeal();
            Path pathos = p.getPath();
            controller.enabled = false;
            transform.position = pathos.mapLocations[p.currentLocation];
            controller.enabled = true;
        }
        else if (health <= 0 && !p){
            StartCoroutine(die());
        }
    }
}
