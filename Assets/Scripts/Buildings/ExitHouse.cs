using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHouse : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;
     private LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            levelLoader.LoadLevel(0);
        }
    }
}
