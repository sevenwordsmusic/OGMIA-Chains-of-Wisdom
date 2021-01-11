using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressTracker : MonoBehaviour
{
    private Text fragmentCounterText;
    private int numberOfFragments;
    public int fragmentsCollected;
    [SerializeField] string playerPrefsKey;

    GameController gameController;


    private void OnEnable()
    {
        GameInitializer.gameInitialized += clearSavedData;
    }

    private void OnDisable()
    {
        GameInitializer.gameInitialized -= clearSavedData;
    }

    private void clearSavedData()
    {
        PlayerPrefs.DeleteKey(playerPrefsKey + gameController.currentLevel);
    }

    private void Awake()
    {
        if(fragmentCounterText == null)
            fragmentCounterText = GameObject.FindGameObjectWithTag("fragmentCounter").GetComponentInChildren<Text>();
        gameController = GameObject.FindGameObjectWithTag("gameController").GetComponent<GameController>();

        if (!PlayerPrefs.HasKey(playerPrefsKey + gameController.currentLevel))
        {
            fragmentsCollected = 0;
            fragmentCounterText.text = fragmentsCollected + " / " + numberOfFragments;
            PlayerPrefs.SetInt(playerPrefsKey + gameController.currentLevel, numberOfFragments);
        } 
        else
        {
            fragmentsCollected = PlayerPrefs.GetInt(playerPrefsKey + gameController.currentLevel);
            fragmentCounterText.text = fragmentsCollected + " / " + numberOfFragments;
        }
    }

    public void fragmentCollected()
    {
        if (fragmentCounterText == null)
            fragmentCounterText = GameObject.FindGameObjectWithTag("fragmentCounter").GetComponentInChildren<Text>();
        fragmentsCollected++;
        PlayerPrefs.SetInt(playerPrefsKey + gameController.currentLevel, fragmentsCollected);
        fragmentCounterText.text = fragmentsCollected + " / " + numberOfFragments;

        if(fragmentsCollected >= numberOfFragments)
        {
            ProgressTracker.PT.addPiece();
            ProgressTracker.PT.isNewSkill = true;
        }
    }

    public void addFragmentToCounter()
    {
        if (fragmentCounterText == null)
            fragmentCounterText = GameObject.FindGameObjectWithTag("fragmentCounter").GetComponentInChildren<Text>();
        numberOfFragments++;
        fragmentCounterText.text = fragmentsCollected + " / " + numberOfFragments;
    }

    // Update is called once per frame
    void Start()
    {
        if (fragmentCounterText == null)
            fragmentCounterText = GameObject.FindGameObjectWithTag("fragmentCounter").GetComponentInChildren<Text>();
        gameController = GameObject.FindGameObjectWithTag("gameController").GetComponent<GameController>();
    }
}
