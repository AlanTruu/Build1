using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode<T> 
{
    private TreeNode<T> first;
    private TreeNode<T> second;
    private TreeNode<T> third;
    private TreeNode<T> fourth;
    private T decision;
    private bool isNPC;
    public TreeNode() {
        first = null;
        second = null;
        third = null;
        fourth = null;
        decision = default(T);
        isNPC = false;
    }

    public TreeNode(T decision) {
        first = null;
        second = null;
        third = null;
        fourth = null;
        this.decision = decision;
        isNPC = false;
    }

    public TreeNode(T decision, bool yes) {
        first = null;
        second = null;
        third = null;
        fourth = null;
        this.decision = decision;
        isNPC = yes;
    }

    public void setFirst(TreeNode<T> first) {
        this.first = first;
    }
    
    public TreeNode<T> getFirst() {
        return first;
    }

    public void setSecond(TreeNode<T> second) {
        this.second = second;
    }

    public TreeNode<T> getSecond() {
        return second;
    }

    public void setThird(TreeNode<T> third) {
        this.third = third;
    }

    public TreeNode<T> getThird() {
        return third;
    }

    public void setFourth(TreeNode<T> fourth) {
        this.fourth = fourth;
    }

    public TreeNode<T> getFourth() {
        return fourth;
    }
    
    public void setDecision(T decision) {
        this.decision = decision;
    }

    public T getDecision() {
        return decision;
    }

    public void setSpeaker(bool npc) {
        isNPC = npc;
    }

    public bool getSpeaker() {
        return isNPC;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
