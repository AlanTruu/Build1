using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int currentLocation;
    [SerializeField] Path path;
    [SerializeField] InputField destination;
    [SerializeField] LoadingScreen loading;
    [SerializeField] Text trafficText;
    [SerializeField] Image trafficImage;
    public int timeToLoad = 2;
    CharacterController controller;
    Queue<string> trafficString = new Queue<string>();
    Queue<Sprite> trafficSprite = new Queue<Sprite>();
    public int score;
    // Start is called before the first frame update

    public void deactivateLoadingScreen() {
        loading.close();
    }
    public void activateLoadingScreen() {
        loading.open();
        Invoke(nameof(deactivateLoadingScreen), timeToLoad);
    }

    public Path getPath() {
        return path;
    }
    public void travel() {
        int destinationNode = destination.text[0] - '0';
        List<ValueTuple<int, double>> adj = path.pleiades.adjacencyList[currentLocation];

        foreach (var(node, weight) in adj) {
            //if chosen node is in adjacency lilst, set transform's position to coordinates in path's map
            Debug.Log(adj + " node: " + node);
            Debug.Log("Node: " + node + " Destination: " + destinationNode);
            if (node == destinationNode) {
                activateLoadingScreen();
                controller.enabled = false;
                transform.position = path.mapLocations[node];
                currentLocation = destinationNode;
                controller.enabled = true;
                

                //change trafficText's string to return of traffic(), dequeue first string to get traffic cause and append
                trafficText.text = path.pleiades.traffic();
                trafficText.text += trafficString.Dequeue();
                trafficImage.sprite = trafficSprite.Dequeue();
                path.pleiades.traffic();
                path.pleiades.traffic();
                path.pleiades.traffic();
                return;

               
            }
        }
        Debug.Log("Location not found or is not accessible");
        
    }

         

    void Start()
    {
        score = 0;
        currentLocation = 0;
        controller = GetComponent<CharacterController>();
        trafficString.Enqueue(" horde of space sharks ");
        trafficString.Enqueue(" runaway blackhole passing through ");
        trafficString.Enqueue(" space pirates ");
        trafficString.Enqueue(" traffic accidents ");
        trafficString.Enqueue(" spice protesting ");
        trafficString.Enqueue(" Trade Union blockade ");
        trafficString.Enqueue(" eldritch horror spotted ");
        trafficString.Enqueue(" bug invasion ");
        trafficString.Enqueue(" police chase ");
        trafficString.Enqueue(" ongoing yugioh battle ");

        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/SpaceShark"));
        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/BlackHole"));
        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/SCB"));
        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/crash"));
        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/spiceMelange"));
        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/tradeFeds"));
        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/eHorror"));
        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/bug"));
        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/police"));
        trafficSprite.Enqueue(Resources.Load<Sprite>("Sprites/Slifer"));

        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
