using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class House : MonoBehaviour
{

   [Header("Components")]
    [SerializeField] public GameObject houseColl;
    [SerializeField] public HouseSpriteController houseSpriteController;
    [SerializeField] public Transform point;
    [SerializeField] public GameObject lights;
    [SerializeField] public GameObject timeBar;
    [SerializeField] public GameObject bar;
    [SerializeField] public GameObject MaterialPanel;

    [Header("Amount")]
    [SerializeField] public TextMeshPro txtPlayerWoodAmount;
    [SerializeField] public TextMeshPro txtNeedWoodAmount;

    public bool canBuild;
    private DayController dayControllerScript;

    private void Start()
    {

        dayControllerScript = FindObjectOfType<DayController>();
        canBuild = true;
    }


    private void Update()
    {
        if (dayControllerScript.lightsOn)
        {
            lights.SetActive(true);
        }
        else
        {
            lights.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) 
        { 
            canBuild = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            canBuild = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canBuild = true;
    }
}
