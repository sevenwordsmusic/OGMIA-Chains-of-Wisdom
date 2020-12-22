using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
///<summary>
///Script dedicado a simular impactos de fuerzas en characterControllers
///</summary>
public class ForceApplier : MonoBehaviour
{
    [SerializeField] float mass = 3.0f; // defines the character mass
    Vector3 impact = Vector3.zero;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // call this function to add an impact force:
    public void AddImpact(Vector3 dir, float force)
    {
        
        dir.Normalize();
        //if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass; //Añade un impacto en la dirección indicada, con la fuerza indicada, dependiendo de la masa del objeto.
    }

    private void Update()
    {
        // apply the impact force:
        if (impact.magnitude > 0.2)
        {
                characterController.Move(impact * Time.deltaTime);
        }

        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
}
