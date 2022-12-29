using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    private Casting cast;

    private bool isHitting;

    private float timeCount;
    private float recoveryTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

        cast = FindObjectOfType<Casting>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
        timeCount += Time.deltaTime;

        if (isHitting)
        {
            if (timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0;
            }
        }
    }

    #region Movement
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetBool("isRoll",true);
            }
            else
            {
                anim.SetInteger("transition", 1);
            }     
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }

        if (player.isDigging)
        {
            anim.SetInteger("transition", 4);
        }

        if (player.isWatering)
        {
            anim.SetInteger("transition", 5);
        }
    }

    void OnRun()
    {
        if (player.isRunning && player.direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 2);
        }
    }
    #endregion


    //é chamado quando o jogador pressiona o botão de ação na agua
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    //é chamado quando termina a animação de pescar
    public void OnCastingsEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted()
    {
        anim.SetBool("hammering", true);
    }

    public void OnHammeringEnded()
    {
        anim.SetBool("hammering", false);
    }

    public void OnHit()
    {
        if (!isHitting) { 
            anim.SetBool("hit",true);
            isHitting = true;
            anim.SetBool("hit",false);
        }
    }
}
