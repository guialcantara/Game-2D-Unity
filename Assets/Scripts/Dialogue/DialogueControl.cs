using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum i18n
    {
        portuguese,
        english,
        spanish
    }

    public i18n language;


    [Header("Components")]
    public GameObject dialogueObj; // dialogue windows
    public Image profileSprite; // profile sprite
    public Text speechText; // speech text
    public Text actorNameText; // npc name

    [Header("Settings")]
    public float typingSpeed; // speech speed

    private int _index; //sentences _index
    private string[] sentences;
    public static DialogueControl instance;
    public int index { get => _index; set => _index = value; }

    //awake is called before all Start() in sripts hierarchy
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[_index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pass to the next sentence
    public void NextSentence()
    {
        if(speechText.text == sentences[_index])
        {
            if(_index < sentences.Length - 1)
            {
                _index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                _index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
            }
        }

    }

    //call the npc speech
    public void Speech(string[] txt)
    {
        if (!dialogueObj.activeInHierarchy)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
        }
    }
}
