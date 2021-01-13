using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PixelCrushers.DialogueSystem;

public class GeneralHUDController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] CombatController combatController;
    [SerializeField] GameObject mobileRoundAttackButton;
    [SerializeField] GameObject mobileBlockButton;
    private Animator animator;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        //Activamos la nueva skill
        playerController.DashUpgrade = true;

        DialogueManager.StartConversation("Fragment_Counter_Tutorial");
    }

    public void triggerAssembleConversation()
    {
        DialogueManager.StartConversation("End_Tutorial");
    }

    public void triggerFirstCrystalConversation()
    {
        if (ProgressTracker.PT.isNewSkill)
        {
            DialogueManager.StartConversation("RoundAttack_Skill_Obtained");

            //Activamos la nueva skill
            combatController.roundAttackUpgrade = true;
            mobileRoundAttackButton.SetActive(true);

            ProgressTracker.PT.isNewSkill = false;
        }
        else
        {
            //PLAY INCREASE HEALTH BAR ANIMATION
            animator.SetTrigger("upgrade1");
            //Increase player health
            combatController.upgradeHealth1();
        }

    }

    public void triggerSecondCrystalConversation()
    {
        if (ProgressTracker.PT.isNewSkill)
        {
            DialogueManager.StartConversation("RoundAttack_Skill_Obtained");

            //Activamos la nueva skill
            combatController.roundAttackUpgrade = true;
            mobileRoundAttackButton.SetActive(true);

            ProgressTracker.PT.isNewSkill = false;
        }
        else
        {
            //PLAY INCREASE HEALTH BAR ANIMATION
            animator.SetTrigger("upgrade1");
            //Increase player health
            combatController.upgradeHealth1();
        }
    }

    public void triggerThirdCrystalConversation()
    {
        if (ProgressTracker.PT.isNewSkill)
        {
            DialogueManager.StartConversation("Block_Skill_Obtained");

            //Activamos la nueva skill
            combatController.blockUpgrade = true;
            mobileBlockButton.SetActive(true);

            ProgressTracker.PT.isNewSkill = false;
        }
        else
        {
            //PLAY INCREASE HEALTH BAR ANIMATION
            animator.SetTrigger("upgrade2");
            //Increase player health
            combatController.upgradeHealth2();
        }
    }

    public void triggerLastCrystalConversation()
    {
        if (ProgressTracker.PT.isNewSkill)
        {
            DialogueManager.StartConversation("Block_Skill_Obtained_final");

            //Activamos la nueva skill
            combatController.blockUpgrade = true;
            mobileBlockButton.SetActive(true);

            ProgressTracker.PT.isNewSkill = false;
        }
        else
        {
            //PLAY INCREASE HEALTH BAR ANIMATION
            animator.SetTrigger("upgrade2");
            //Increase player health
            combatController.upgradeHealth2();
        }
    }

    public void triggerUpgradeHealth1Conversation()
    {
        DialogueManager.StartConversation("Health_Upgrade_1");
    }

    public void triggerUpgradeHealth2Conversation()
    {
        if(ProgressTracker.PT.numberOfPieces >= 6)
        {
            DialogueManager.StartConversation("Health_Upgrade_2_final");
        } 
        else
        {
            DialogueManager.StartConversation("Health_Upgrade_2");
        }
    }

}
