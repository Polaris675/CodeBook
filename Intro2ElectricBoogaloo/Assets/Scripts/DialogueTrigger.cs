using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager manager;
    public Dialogue dialougeText;
    public KeyCode interact;
    public bool interactable;
    public UnityEvent triggerOnInteract;
    public UnityEvent triggerOnCollision;
    public UnityEvent triggerOnCollide;
    public UnityEvent onSceneEnter;

    private void Awake()
    {
        onSceneEnter.Invoke();
        TriggerDialogue();
    }
    
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (interactable == false)
        {
            triggerOnCollision.Invoke();
            TriggerDialogue();
        }
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (interactable == true && Input.GetKeyDown(interact) == true)
        {
            triggerOnInteract.Invoke();
            TriggerDialogue();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactable == false)
        {
            triggerOnCollide.Invoke();
            TriggerDialogue();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (interactable == true && Input.GetKeyDown(interact) == true)
        {
            triggerOnInteract.Invoke();
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        manager.StartDialogue(dialougeText);
    }

}