using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [TextArea(3, 10)]
    public List<string> StartDialogue;
    [TextArea(3, 10)]
    public List<string> TransitionalDialogue;
    [TextArea(3, 10)]
    public List<string> EndDialogue;

    public void Awake()
    {
       
    }

    public void TriggerDialogue()
    {
        dialogue.sentences[0] = StartDialogue[Random.Range(0, StartDialogue.Count)];
        dialogue.sentences[1] = TransitionalDialogue[Random.Range(0, StartDialogue.Count)];
        dialogue.sentences[2] = EndDialogue[Random.Range(0, StartDialogue.Count)];
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
