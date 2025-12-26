using UnityEngine;
using VIDE_Data;

public class NPCDialogueTrigger : MonoBehaviour
{
    private VIDE_Assign videAssign;
    private bool playerInside = false;
    
    private NPC1Movement _movement;
    
    public DialogueUIManager dialogueUI;


    void Awake()
    {
        _movement = GetComponent<NPC1Movement>();
        videAssign = GetComponent<VIDE_Assign>();
        Debug.Log("VIDE_Assign encontrado: " + (videAssign != null));
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo ha entrado en el trigger: " + other.name);
        if (!playerInside && other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Es el Player");
            StartDialogue();
            Debug.Log("VD.isActive antes: " + VD.isActive);
            Debug.Log("Dialogue name: " + videAssign.assignedDialogue);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void StartDialogue()
    {
        if (videAssign == null) return;
        if (VD.isActive) return;

        if (_movement != null)
            _movement.canMove = false;

        //VD.BeginDialogue(videAssign);
        dialogueUI.Interact(videAssign);

        Debug.Log("VD.isActive DESPUÉS: " + VD.isActive);
        Debug.Log("Current node: " + VD.nodeData);
    }
    void OnEnable()
    {
        VD.OnEnd += OnDialogueEnd;
    }
    void OnDisable()
    {
        VD.OnEnd -= OnDialogueEnd;
    }
    void OnDialogueEnd(VD.NodeData data)
    {
        if (_movement != null)
            _movement.canMove = true;
    }


}