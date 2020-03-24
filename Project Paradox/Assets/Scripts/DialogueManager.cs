using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text NameText;
    public TMP_Text MainText;

    public Animator TextAnim;
    public AudioSource Voice;

    private float TextSpeed = 0.05f;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        NameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        TextSpeed = 0.05f;
        TextAnim.SetBool("Mad", false);
        MainText.fontStyle = FontStyles.Normal;
        StartCoroutine(TypeSentence(sentence));
        //MainText.text = sentence;
    }

    IEnumerator TypeSentence (string sentence)
    {
       
        MainText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            if(letter == '<')
            {
                TextAnim.SetBool("Mad", true);
                MainText.fontStyle = FontStyles.Bold;
                TextSpeed = 0.2f;
            }
            
            MainText.text += letter;
            Voice.pitch = Random.Range(0.5f, 1f);
            Voice.Play();
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    void EndDialogue()
    {

    }
}
