using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public struct DialoguePiece
    {
        public string name;
        public Sprite icon;
        public Sprite dialogueBox;
        public UnityEvent dialogueEvent;
        public bool hasUnityEvent;
        [TextArea(3, 10)]
        public string sentence; 
    }
