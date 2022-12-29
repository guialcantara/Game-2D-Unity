using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;
     private LevelLoader levelLoader;
    private GameObject player;
    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            levelLoader.LoadLevel(1);
            player.transform.position = new Vector3(50, 10, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
            player = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
