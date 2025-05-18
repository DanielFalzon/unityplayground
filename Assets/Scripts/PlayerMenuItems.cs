using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMenuItems : MonoBehaviour
{
    [SerializeField] private GameObject inPlayCanvas;
    [SerializeField] private GameObject journalCanvas;
    private bool isMenuOpen = false;
    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.jKey.wasPressedThisFrame)
        {
            journalCanvas.SetActive(!journalCanvas.activeSelf);
            isMenuOpen = journalCanvas.activeSelf;
        };

        inPlayCanvas.SetActive(!isMenuOpen);
    }
}
