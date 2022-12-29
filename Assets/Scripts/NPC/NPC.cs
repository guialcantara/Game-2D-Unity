using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    private float initialSpeed;

    private int index;
    private Animator anim;

    public List<Transform> paths = new List<Transform>();
    NPC_Dialogue dialog;
    private void Start()
    {
        dialog = GetComponent<NPC_Dialogue>();
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (dialog.playerHit)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, paths[index].position) < 0.2f)
        {
            index = (index < paths.Count - 1) ? index + 1 : 0;
        }

        Vector2 direction = paths[index].position - transform.position;
        
        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

}
