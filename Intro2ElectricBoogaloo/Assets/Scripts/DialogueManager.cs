using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TMP_Text dialogueText;
    public TMPro.TMP_Text characterName;
    public Image icon;
    public Image dialogueBox;
    public KeyCode dialogueContinue;
    public KeyCode dialogueSkip;
    public bool dialogueOpen = false;
    public GameObject dialogue;
    public bool hasPause;

    public UnityEvent endDialogue;

    private Queue<DialoguePiece> conversation;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(dialogueContinue) == true)
        {
            DisplayNextSentence();
        }
        if (Input.GetKeyDown(dialogueSkip) == true)
        {
            this.EndDialogue();
        }
    }
    public void StartDialogue(Dialogue dialouge)
    {
        dialogueOpen = true;
        Time.timeScale = 0;
        conversation = new Queue<DialoguePiece>();
        foreach (DialoguePiece DP in dialouge.conversation)
        {
            conversation.Enqueue(DP);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (conversation.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialoguePiece thisDialogue = conversation.Dequeue();
        characterName.text = thisDialogue.name;
        string sentence = thisDialogue.sentence;
        icon.sprite = thisDialogue.icon;
        dialogueBox.sprite = thisDialogue.dialogueBox;
        if (thisDialogue.hasUnityEvent == true)
        {
            thisDialogue.dialogueEvent.Invoke();
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Time.timeScale = 1;
        dialogueOpen = false;
        endDialogue.Invoke();
    }
}
