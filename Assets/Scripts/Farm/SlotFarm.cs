using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount; //quantidade de "escavação"
    [SerializeField] private float waterAmount; //total de agua para nascer uma cenoura
    [SerializeField] private bool detecting;
    [SerializeField] private bool detectingPlayer;

    private int initialDigAmount;
    private float currentWater;

    private bool dugHole;

    PlayerItens playeritens;

    private void Start()
    {
        playeritens = FindObjectOfType<PlayerItens>();
        initialDigAmount = digAmount;

    }

    private void Update()
    {
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            //encheu total de água necessaria
            if (currentWater >= waterAmount)
            {
                spriteRenderer.sprite = carrot;

                if (Input.GetKeyDown(KeyCode.E) && detectingPlayer && playeritens.Carrots < playeritens.carrotsLimit)
                {
                    spriteRenderer.sprite = hole;
                    playeritens.Carrots++;
                    currentWater = 0f;
                    digAmount = initialDigAmount;
                    dugHole = false;
                    spriteRenderer.sprite = null;
                }
            }
        }     
    }
    public void OnHit()
    {
        digAmount--;

        if(digAmount <= 0)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            OnHit();
        }
        if (collision.CompareTag("Water"))
        {
            detecting = true;
        }

        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            detecting = false;
        }

        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
