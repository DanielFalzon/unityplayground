using System;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] TextMeshProUGUI promptText;

    private void Start()
    {
        mainCamera = Camera.main;
        uiPanel.SetActive(false);
    }

    void LateUpdate()
    {
        var rotation = mainCamera.transform.rotation;
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool isDisplayed = false;
    
    public void SetUp(string text)
    {
        promptText.text = text;
        isDisplayed = true;
        uiPanel.SetActive(true);
    }

    public void Close()
    {
        isDisplayed = false;
        uiPanel.SetActive(false);
    }
}
