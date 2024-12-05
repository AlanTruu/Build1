using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text npcLine;
    [SerializeField] Text choice1;
    [SerializeField] Text choice2;
    [SerializeField] Text choice3;
    [SerializeField] Text choice4;
    public int timeToTurnOff = 2;

    private TreeNode<string> currentNode;
    // Start is called before the first frame update
    public void startDialogue(TreeNode<string> root) {
        currentNode = root;
    }

    public void displayDialogue(TreeNode<string> dialogueNode) {
        npcLine.text = dialogueNode.getFirst().getDecision();
    }

    public void turnOffDialogue() {
        Invoke(nameof(close), timeToTurnOff);
    }
    public void selectOption(int choice) {
        if (choice == 1 && currentNode.getFirst() != null) {
            currentNode = currentNode.getFirst();
            displayDialogue(currentNode);
            choice1.gameObject.SetActive(false);
            choice2.gameObject.SetActive(false);
            choice3.gameObject.SetActive(false);
            choice4.gameObject.SetActive(false);
            turnOffDialogue();
        }
        else if (choice == 2 && currentNode.getSecond() != null) {
            currentNode = currentNode.getSecond();
            displayDialogue(currentNode);
            choice1.gameObject.SetActive(false);
            choice2.gameObject.SetActive(false);
            choice3.gameObject.SetActive(false);
            choice4.gameObject.SetActive(false);
            turnOffDialogue();
        }
        else if (choice == 3 & currentNode.getThird() != null) {
            currentNode = currentNode.getThird();
            displayDialogue(currentNode);
            choice1.gameObject.SetActive(false);
            choice2.gameObject.SetActive(false);
            choice3.gameObject.SetActive(false);
            choice4.gameObject.SetActive(false);
            turnOffDialogue();
        }
        else {
            currentNode = currentNode.getFourth();
            displayDialogue(currentNode);
            choice1.gameObject.SetActive(false);
            choice2.gameObject.SetActive(false);
            choice3.gameObject.SetActive(false);
            choice4.gameObject.SetActive(false);
            turnOffDialogue();
        }
    }
    public void open() {
        gameObject.SetActive(true);
    }
    public void close() {
        gameObject.SetActive(false);
    }
    void Start()
    {
        //close();
        TreeNode<string> root = new TreeNode<string>("You only get one question", true);
        TreeNode<string> child1 = new TreeNode<string>("What?");
        TreeNode<string> child2 = new TreeNode<string>("Who are you?");
        TreeNode<string> child3 = new TreeNode<string>("What is my purpose?");
        TreeNode<string> child4 = new TreeNode<string>("Advice?");
        TreeNode<string> grandChild1 = new TreeNode<string>("...");
        TreeNode<string> grandChild2 = new TreeNode<string>("Bobert");
        TreeNode<string> grandChild3 = new TreeNode<string>("To deliver");
        TreeNode<string> grandChild4 = new TreeNode<string>("Do not let your health drop to 0");
        root.setFirst(child1);
        root.setSecond(child2);
        root.setThird(child3);
        root.setFourth(child4);

        child1.setFirst(grandChild1);
        child2.setFirst(grandChild2);
        child3.setFirst(grandChild3);
        child4.setFirst(grandChild4);
        currentNode = root;
        npcLine.text = currentNode.getDecision();
        choice1.text = currentNode.getFirst().getDecision();
        choice2.text = currentNode.getSecond().getDecision();
        choice3.text = currentNode.getThird().getDecision();
        choice4.text = currentNode.getFourth().getDecision();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
