using System;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    private string animationTrigger; 
    private Animator chestAnimator;
    private bool isOpen;

    public string InteractionPrompt => prompt;

    private void Start()
    {
        chestAnimator = GetComponentInChildren<Animator>();
        isOpen = false;
        prompt = "Open Chest";
        
        if (chestAnimator == null)
        {
            Debug.LogError($"Animator component not found on the parent of {gameObject.name}");
            enabled = false; // Disable the Chest script if no Animator is found
        }
    }
    
    private void Update()
    {
        if (isOpen)
        {
            animationTrigger = "CloseChestTrigger";
            prompt = "Close Chest";
        }
        else
        {
            animationTrigger = "OpenChestTrigger";
            prompt = "Open Chest";
        }
    }

    
    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory is null || !inventory.hasKey) return false;

        isOpen = !isOpen;
        chestAnimator.SetTrigger(animationTrigger);
        
        return true;
    }
}
