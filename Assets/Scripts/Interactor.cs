using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;
    
    private IInteractable interactable;
    
    //How many things we search for in the radius
    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, _colliders, interactableMask);

        if (_numFound > 0)
        { 
            
            interactable = _colliders[0].GetComponent<IInteractable>();
            if (interactable is not null)
            {
                if(!interactionPromptUI.isDisplayed) interactionPromptUI.SetUp(interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame) interactable.Interact(this);
                
                interactable.Interact(this);
            }
        }
        else
        {
            if(interactable != null ) interactable = null;
            if(interactionPromptUI.isDisplayed) interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
