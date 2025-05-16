using System;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    private Camera mainCamera;
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
        uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close()
    {
        isDisplayed = false;
        uiPanel.SetActive(false);
    }
}
