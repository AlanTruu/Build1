using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Graph 
{
    public List<ValueTuple<int, double>>[] adjacencyList;
    

        // Constructor to initialize adjacency list
    public Graph(int vertices)
    {
        adjacencyList = new List<ValueTuple<int, double>>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            adjacencyList[i] = new List<ValueTuple<int, double>>();
        }
    }

    //method to add an edge between two nodes, does both directions
    public void addEdge(int u, int v, double weight)
    {
        adjacencyList[u].Add((v, weight));
        adjacencyList[v].Add((u, weight));
    }


    public List<int> dijkstra(int startNode, int endNode) {
        int v = adjacencyList.Length;
        double[] distances = new double[v];
        bool[] visited = new bool[v];
        int[] predecessor = new int[v];
        SortedSet<(double, int)> priority = new SortedSet<(double, int)>();

        for (int i = 0; i < v; i++) {
            distances[i] = double.MaxValue;
            predecessor[i] = -1;
        }
        distances[startNode] = 0;

        priority.Add((0, startNode));

        while (priority.Count > 0) {
            var (distanceFromStart, currentNode) = priority.Min;
            priority.Remove(priority.Min);
            
            //if currentNode has been visited before, skip this iteration to prevent backtracking, otherwise set it to true in visited
            if (visited[currentNode]) {
                continue;
            }
            visited[currentNode] = true;

            //search currentNode's adjacency list, if a new shorter path to a node has been discovered, remove any paths 
            //to that node in priority to prevent redundancy, update distance and predecessor arrays, then add the newDistance and node associated into priority
            foreach(var(neighborNode, weight) in adjacencyList[currentNode]) {
                double newDistance = distanceFromStart + weight;
                if (newDistance < distances[neighborNode]) {
                    priority.Remove((distances[neighborNode], neighborNode));
                    distances[neighborNode] = newDistance;
                    predecessor[neighborNode] = currentNode;
                    priority.Add((newDistance, neighborNode));
                }
            }
        }
        
        //starting from endNode, build a new List using entries from predecessor to create path from endNode to startNode, then reverse it
        List<int> path = new List<int>();
        for (int i = endNode; i != -1; i = predecessor[i]) {
            path.Add(i);
        }
        path.Reverse();
        return path;

    }

    //methods to get and alter weights, will be used to simulate traffic
    public double getWeight(int from, int to) {
        foreach (var(neighbor, weight) in adjacencyList[from]) {
            if (neighbor == to) {
                return weight;
            }
            
        }
        return -1.0f;
    }

    //Get Index of node to in from's adjacency list
     public int getIndex(int from, int to) {
        for (int i = 0; i < adjacencyList[from].Count; i++) {
            if (adjacencyList[from].ElementAt(i).Item1 == to) {
                return i;
            }
        }
        return -1;
    }

    //add weight to edge from -> to
    public bool addWeight(int from, int to, double addedWeight) {
        double oldWeight = getWeight(from, to);
        if (adjacencyList[from].Contains((to, oldWeight))) {
            int changeIndex = getIndex(from, to);
            adjacencyList[from].Insert(changeIndex, (to, oldWeight + addedWeight));
            return true;
        }
        return false;
    } 

   
    public string traffic() {
        System.Random randomNode = new System.Random();
        System.Random randomEdge = new System.Random();
        System.Random randomWeight = new System.Random();

        int node = randomNode.Next(0, adjacencyList.Length);
        List<ValueTuple<int, double>> adj = adjacencyList[node];
        int edgeIndex = randomEdge.Next(0, adj.Count);
        
        Debug.Log("From node " + node + " to " + adjacencyList[node].ElementAt(edgeIndex).Item1 + " with oldweight of " + getWeight(node, adjacencyList[node].ElementAt(edgeIndex).Item1));
        addWeight(node, adjacencyList[node].ElementAt(edgeIndex).Item1, randomWeight.Next(1, 10));
        
        Debug.Log("At node " + node + " to " + adjacencyList[node].ElementAt(edgeIndex));
        
        string trafficUpdate = "Highway from " + node.ToString() + " to " + adjacencyList[node].ElementAt(edgeIndex).Item1.ToString() + " experiencing traffic due to ";
        return trafficUpdate;
    }

}

