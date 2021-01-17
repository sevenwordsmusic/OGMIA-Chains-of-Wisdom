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

    [Header("Amulet References", order = 0)]
    [SerializeField] GameObject Base;
    [SerializeField] GameObject Heart;
    [SerializeField] GameObject FirstCrystal;
    [SerializeField] GameObject SecondCrystal;
    [SerializeField] GameObject ThirdCrystal;
    [SerializeField] GameObject LastCrystal;

    private void Awake()
    {
        MidNightDreamController.checkAmulet += checkAmuletProgress;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        MidNightDreamController.checkAmulet -= checkAmuletProgress;
    }

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

    public void checkAmuletProgress()
    {
        int numberOfPieces = PlayerPrefs.GetInt("numberOfPieces");
        print(numberOfPieces);
        switch (ProgressTracker.PT.numberOfPieces)
        {
            case 1:
                Heart.SetActive(true);
                break;

            case 2:
                Base.SetActive(true);
                Heart.SetActive(true);
                break;

            case 3:
                Base.SetActive(true);
                Heart.SetActive(true);
                FirstCrystal.SetActive(true);
                break;

            case 4:
                Base.SetActive(true);
                Heart.SetActive(true);
                FirstCrystal.SetActive(true);
                SecondCrystal.SetActive(true);
                break;

            case 5:
                Base.SetActive(true);
                Heart.SetActive(true);
                FirstCrystal.SetActive(true);
                SecondCrystal.SetActive(true);
                ThirdCrystal.SetActive(true);
                break;

            case 6:
                Base.SetActive(true);
                Heart.SetActive(true);
                FirstCrystal.SetActive(true);
                SecondCrystal.SetActive(true);
                ThirdCrystal.SetActive(true);
                LastCrystal.SetActive(true);
                break;

            default:
                print("WARNING: " + ProgressTracker.PT.numberOfPieces + " pieces of amulet. Unexpected amount");
                break;

        }
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
        print("isNewSkill: " + ProgressTracker.PT.isNewSkill);
        if (ProgressTracker.PT.isNewSkill == true)
        {
            DialogueManager.StartConversation("Block_Skill_Obtained");

            //Activamos la nueva skill
            combatController.blockUpgrade = true;
            mobileBlockButton.SetActive(true);


            //ProgressTracker.PT.isNewSkill = false;
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
        print("isNewSkill: " + ProgressTracker.PT.isNewSkill);
        if (ProgressTracker.PT.isNewSkill == true)
        {
            DialogueManager.StartConversation("Block_Skill_Obtained");

            //Activamos la nueva skill
            combatController.blockUpgrade = true;
            mobileBlockButton.SetActive(true);

            //ProgressTracker.PT.isNewSkill = false;
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
        print("isNewSkill: " + ProgressTracker.PT.isNewSkill);
        if (ProgressTracker.PT.isNewSkill == true)
        {
            DialogueManager.StartConversation("RoundAttack_Skill_Obtained");

            //Activamos la nueva skill
            combatController.roundAttackUpgrade = true;
            mobileRoundAttackButton.SetActive(true);

            //ProgressTracker.PT.isNewSkill = false;
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
        print("isNewSkill: " + ProgressTracker.PT.isNewSkill);
        if (ProgressTracker.PT.isNewSkill == true)
        {
            DialogueManager.StartConversation("RoundAttack_Skill_Obtained_final");


            //Activamos la nueva skill
            combatController.roundAttackUpgrade = true;
            mobileRoundAttackButton.SetActive(true);


            //ProgressTracker.PT.isNewSkill = false;
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
        checkAmuletProgress();
        DialogueManager.StartConversation("Health_Upgrade_1");
    }

    public void triggerUpgradeHealth2Conversation()
    {
        checkAmuletProgress();
        if (ProgressTracker.PT.numberOfPieces >= 6)
        {
            DialogueManager.StartConversation("Health_Upgrade_2_final");
        } 
        else
        {
            DialogueManager.StartConversation("Health_Upgrade_2");
        }
    }

}
