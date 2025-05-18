using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Door : MonoBehaviour, IInteractable
{
    
    [SerializeField] private string openDoorTrigger; 
    [SerializeField] private string closeDoorTrigger; 
    [SerializeField] private Animator animator;
    private string _prompt;
    
    private bool _isOpen;
    
    public string InteractionPrompt => _prompt;
    
    private void Start()
    {
        _isOpen = false;
        _prompt = "Open Door";

        // Ensure an Animator component exists on the parent
        if (animator == null)
        {
            Debug.LogError($"Animator component not found on the parent of {gameObject.name}");
            enabled = false; // Disable the Door script if no Animator is found
        }
    }

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory is null || !inventory.hasKey) return false;

        _isOpen = !_isOpen;
        if (_isOpen)
        {
            animator.SetTrigger(openDoorTrigger);
            _prompt = "Close Door";
        }
        else
        {
            animator.SetTrigger(closeDoorTrigger);
            _prompt = "Open Door";
        }
        
        return true;
    }
}
