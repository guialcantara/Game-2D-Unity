using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float timeMove;
    private float timeCount;
    private float speed;
    PlayerItens playeritens;
    void Start()
    {
        playeritens = FindObjectOfType<PlayerItens>();
        speed = Random.Range(-4f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount < timeMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playeritens.TotalWood < playeritens.woodLimit)
        {
            playeritens.TotalWood++;
            Destroy(gameObject);

        }
    }
}
