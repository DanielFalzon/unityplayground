using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    private Animator doorAnimator;
    private bool isOpen;
    [SerializeField] private string animationTrigger; 
    
    public string InteractionPrompt => prompt;
    
    private void Start()
    {
        // Get the Animator component from the parent GameObject
        doorAnimator = GetComponentInParent<Animator>();
        isOpen = false;
        prompt = "Open Door";

        // Ensure an Animator component exists on the parent
        if (doorAnimator == null)
        {
            Debug.LogError($"Animator component not found on the parent of {gameObject.name}");
            enabled = false; // Disable the Door script if no Animator is found
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            animationTrigger = "CloseDoorTrigger";
            prompt = "Close Door";
        }
        else
        {
            animationTrigger = "OpenDoorTrigger";
            prompt = "Open Door";
        }
    }

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory is null || !inventory.hasKey) return false;

        isOpen = !isOpen;
        doorAnimator.SetTrigger(animationTrigger);
        
        return true;
    }
}
