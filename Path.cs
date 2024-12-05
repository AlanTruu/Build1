using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Path : MonoBehaviour
{
    [SerializeField] Text text01;
    [SerializeField] Text text10;
    [SerializeField] Text text12;
    [SerializeField] Text text21;
    [SerializeField] Text text13;
    [SerializeField] Text text31;
    [SerializeField] Text text23;
    [SerializeField] Text text32;
    [SerializeField] Text text34;
    [SerializeField] Text text43;
    [SerializeField] Text text25;
    [SerializeField] Text text52;
    [SerializeField] Text text45;
    [SerializeField] Text text54;
    [SerializeField] Text text26;
    [SerializeField] Text text62;
    [SerializeField] Text text56;
    [SerializeField] Text text65;
    [SerializeField] Text text57;
    [SerializeField] Text text75;
    [SerializeField] Text text67;
    [SerializeField] Text text76;
    [SerializeField] Text text68;
    [SerializeField] Text text86;
    [SerializeField] InputField input;
    [SerializeField] Text displayText;

    
    public Graph pleiades;
    public Dictionary<int, Vector3> mapLocations = new Dictionary<int, Vector3>();
    public void route() {
        string read = input.text;
        int from = (read[0]) - '0';
        int to = (read[1]) - '0';
        List<int> path = pleiades.dijkstra(from, to);
        string write = "";
        for (int i = 0; i < path.Count; i++) {
            write += path[i].ToString() + " ";
        }
        displayText.text = write;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        pleiades = new Graph(9);
        pleiades.addEdge(0, 1, 2.151);
        pleiades.addEdge(1, 2, 2.363);
        pleiades.addEdge(1, 3, 3.431);
        pleiades.addEdge(2, 3, 2.339);
        pleiades.addEdge(2, 5, 5.611);
        pleiades.addEdge(2, 6, 4.111);
        pleiades.addEdge(3, 4, 2.363);
        pleiades.addEdge(4, 5, 7.487);
        pleiades.addEdge(5, 6, 5.707);
        pleiades.addEdge(5, 7, 2.145);
        pleiades.addEdge(6, 7, 4.910);
        pleiades.addEdge(6, 8, 6.287);
        mapLocations.Add(0, new Vector3(-20.08f, 5.74f, -57.9f));
        mapLocations.Add(1, new Vector3(538.02f, 58f, 50.3f));
        mapLocations.Add(2, new Vector3(-779.772f, 118.181f, 4.5f));
        mapLocations.Add(3, new Vector3(213f, 18f, -94f));
        mapLocations.Add(4, new Vector3(422.49f, 142f, -141f));
        

    }

    // Update is called once per frame
    void Update()
    {
        text01.text = pleiades.getWeight(0, 1).ToString();
        text10.text = pleiades.getWeight(1, 0).ToString();
        text12.text = pleiades.getWeight(1, 2).ToString();
        text21.text = pleiades.getWeight(2, 1).ToString();
        text13.text = pleiades.getWeight(1, 3).ToString();
        text31.text = pleiades.getWeight(3, 1).ToString();
        text23.text = pleiades.getWeight(2, 3).ToString();
        text32.text = pleiades.getWeight(3, 2).ToString();
        text34.text = pleiades.getWeight(3, 4).ToString();
        text43.text = pleiades.getWeight(4, 3).ToString();
        text25.text = pleiades.getWeight(2, 5).ToString();
        text52.text = pleiades.getWeight(5, 2).ToString();
        text45.text = pleiades.getWeight(4, 5).ToString();
        text54.text = pleiades.getWeight(5, 4).ToString();
        text26.text = pleiades.getWeight(2, 6).ToString();
        text62.text = pleiades.getWeight(6, 2).ToString();
        text56.text = pleiades.getWeight(5, 6).ToString();
        text65.text = pleiades.getWeight(6, 5).ToString();
        text57.text = pleiades.getWeight(5, 7).ToString();
        text75.text = pleiades.getWeight(7, 5).ToString();
        text67.text = pleiades.getWeight(6, 7).ToString();
        text76.text = pleiades.getWeight(7, 6).ToString();
        text68.text = pleiades.getWeight(6, 8).ToString();
        text86.text = pleiades.getWeight(8, 6).ToString();

    }
}
