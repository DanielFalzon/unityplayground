using TMPro;
using UnityEngine;

public class StarterScript : MonoBehaviour
{
    [SerializeField] private int myNumber;
    [SerializeField] private string myName;
    [SerializeField] private bool myChoice;
    [SerializeField] private GameObject myGate;

    [SerializeField] private GameObject name1;
    [SerializeField] private GameObject name2;
    

    int myOtherNunmber;
    private TMP_Text _name1Component;
    private TMP_Text _name2Component;

    //once on start 
    private void Start()
    {
        _name1Component = name1.GetComponent<TMP_Text>();
        _name2Component = name2.GetComponent<TMP_Text>();
        myNumber = 4;
        myName = "Daniel";
        myChoice = true;
        myGate.SetActive(true);
    }

    //Once per frame    
    void Update()
    {
        switch (myNumber)
        {
            case 0:
                _name1Component.text = "";
                _name2Component.text = "";
                break;
            case 4:
                myName = "Dan";
                _name1Component.text = $"My Number: {myNumber} My Name: {myName}";
                _name2Component.text = "Fred is inactive";
                break;
            default:
                myName = "Fred";
                _name1Component.text = "Dan is inactive";
                _name2Component.text = $"My Number: {myNumber} My Name: {myName}";
                break;
        }
    }
}
