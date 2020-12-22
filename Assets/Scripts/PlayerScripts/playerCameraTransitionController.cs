using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class playerCameraTransitionController : MonoBehaviour
{
    [SerializeField] PlayableDirector originalCamera;
    [SerializeField] PlayableDirector newCameraPoint;
    private CombatController combatController;

    private void Awake()
    {
        combatController = GetComponentInParent<CombatController>();
    }

    private void OnEnable()
    {
        CombatController.playerDeath += deathTransition;
    }

    private void OnDisable()
    {
        CombatController.playerDeath -= deathTransition;
    }

    public void deathTransition()
    {
        this.GetComponent<PlayableDirector>().Play();
    }
}
