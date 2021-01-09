using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PixelCrushers.DialogueSystem;

public class GeneralHUDController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] CombatController combatController;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = playerController.gameObject.GetComponent<PlayerInput>();
    }

    public void disablePlayerInput()
    {
        playerInput.DeactivateInput();
        playerController.disableMovement();
        combatController.disableAttack();
    }

    public void enablePlayerInput()
    {
        playerInput.ActivateInput();
        playerController.enableMovement();
        combatController.enableAttack();
    }

    public void triggerCoreConversation()
    {
        DialogueManager.StartConversation("Fragment_Counter_Tutorial");
    }

    public void triggerAssembleConversation()
    {
        DialogueManager.StartConversation("End_Tutorial");
    }

    public void triggerFirstCrystalConversation()
    {
        DialogueManager.StartConversation("First_Crystal_Obtained");
    }

    public void triggerSecondCrystalConversation()
    {
        DialogueManager.StartConversation("Second_Crystal_Obtained");
    }

    public void triggerThirdCrystalConversation()
    {
        DialogueManager.StartConversation("Third_Crystal_Obtained");
    }

    public void triggerLastCrystalConversation()
    {
        DialogueManager.StartConversation("Last_Crystal_Obtained");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
