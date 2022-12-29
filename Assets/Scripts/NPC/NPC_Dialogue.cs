using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;

   public bool playerHit;
    private List<string> sentences = new List<string>();

    private void Start()
    {
        GetNPCInfo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }


    void GetNPCInfo()
    { 
        for(int i = 0; i< dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.i18n.portuguese:
                    sentences.Add(dialogue.dialogues[i].sentence.pt_br);
                    break;
                case DialogueControl.i18n.english:
                    sentences.Add(dialogue.dialogues[i].sentence.en_us);
                    break;
                case DialogueControl.i18n.spanish:
                    sentences.Add(dialogue.dialogues[i].sentence.es_es);
                    break;
            }         
        }
    }

    // FixedUpdate is used for physics
    void FixedUpdate()
    {
        TriggerDialogue();
    }

    void TriggerDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogueControl.instance.dialogueObj.SetActive(false);
            DialogueControl.instance.speechText.text = "";
            DialogueControl.instance.index = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

}
