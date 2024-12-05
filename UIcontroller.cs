using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private Text healthLabel;
    [SerializeField] settingsPopUp pop;
    [SerializeField] private DialoguePop dialoguePop;
    [SerializeField] private Text scoreLabel;
    private bool inTalkingRange;
    private bool inFaceRange;
    private float talkingRange = 3f;
    public LayerMask whatIsPlayer;
    public LayerMask whatIsFace;
    private Life life;
    private Player p;
    private bool openMap;
    private bool cursorInUse;
    private Transform face;
    // Start is called before the first frame update
    void Start()
    {
        life = GameObject.Find("Player").GetComponent<Life>();
        p = GameObject.Find("Player").GetComponent<Player>();
        face = GameObject.Find("face").transform;
        pop.close();
        dialoguePop.close();
        openMap = false;
        cursorInUse = false;
      
    }

    public void onPointerDown() {
        Debug.Log("Pointer down");
    }

    public void onOpen() {
        pop.open();
    }
    // Update is called once per frame
    void Update()
    {
        healthLabel.text = "  " + life.health.ToString();
        scoreLabel.text = p.score + "/" + 9;

        if (Input.GetKeyDown("tab") && openMap == false && !cursorInUse) {
            openMap = true;
            cursorInUse = true;
            pop.open();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown("tab") && openMap == true && cursorInUse) {
            openMap = false;
            cursorInUse = false;
            pop.close();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("new version");
        }

        inFaceRange = Physics.CheckSphere(p.transform.position, talkingRange, whatIsFace);
        inTalkingRange = Physics.CheckSphere(face.position, talkingRange, whatIsPlayer);
        if (inFaceRange && !cursorInUse) {
            dialoguePop.open();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!inFaceRange && !openMap){
            dialoguePop.close();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}
