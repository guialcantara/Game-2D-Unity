using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    PlayerItens playeritens;

    void Start()
    {
        playeritens = FindObjectOfType<PlayerItens>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playeritens.Fishes < playeritens.fishesLimit)
        {
            playeritens.Fishes++;
            Destroy(gameObject);

        }
    }
}
