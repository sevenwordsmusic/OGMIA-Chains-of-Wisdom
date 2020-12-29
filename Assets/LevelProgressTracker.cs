using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressTracker : MonoBehaviour
{
    private Text fragmentCounterText;
    private int numberOfFragments;
    private int fragmentsCollected;
    [SerializeField] string playerPrefsKey;


    private void Awake()
    {
        fragmentCounterText = GameObject.FindGameObjectWithTag("fragmentCounter").GetComponentInChildren<Text>();

        if (!PlayerPrefs.HasKey(playerPrefsKey))
        {
            fragmentsCollected = 0;
            fragmentCounterText.text = fragmentsCollected + " / " + numberOfFragments;
            PlayerPrefs.SetInt(playerPrefsKey, numberOfFragments);
        } 
        else
        {
            fragmentsCollected = PlayerPrefs.GetInt(playerPrefsKey);
            fragmentCounterText.text = fragmentsCollected + " / " + numberOfFragments;
        }
    }

    public void fragmentCollected()
    {
        fragmentsCollected++;
        PlayerPrefs.SetInt(playerPrefsKey, fragmentsCollected);
        fragmentCounterText.text = fragmentsCollected + " / " + numberOfFragments;

        if(fragmentsCollected >= numberOfFragments)
        {
            ProgressTracker.PT.addPiece();
        }
    }

    public void addFragmentToCounter()
    {
        numberOfFragments++;
        fragmentCounterText.text = fragmentsCollected + " / " + numberOfFragments;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
