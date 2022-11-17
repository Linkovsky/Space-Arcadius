using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Arcade.Dialogue;
using TMPro;
using UnityEngine;

namespace Arcade.Dialogue
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private DialogueScript dialogueText;
    
        private TextMeshProUGUI text;
        private WaitForSeconds charDelay;
        private Coroutine coroutineVar;
        private bool isRunning = false;
        private string dialogue;
        private void Awake()
        {
            charDelay = new WaitForSeconds(0.1f);
            text = GetComponent<TextMeshProUGUI>();
            text.text = "";
        }
    
        private IEnumerator Start()
        {
            foreach (var t in dialogueText.Text)
            {
                text.text = "";
                dialogue = t;
                isRunning = true;
                //TODO: Manage the coroutine so after it stops it gets back to the parent and continue
                yield return coroutineVar = StartCoroutine(StartDialogue());
                text.text = dialogue;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
            }
            text.text = "";
        }
    
        private void Update()
        {
            if(isRunning)
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    isRunning = false;
                    StopCoroutine(coroutineVar);
                    coroutineVar = null;
                }
                    
        }
    
        private IEnumerator StartDialogue()
        {
            foreach (var t in dialogue)
            {
                text.text += t;
                yield return charDelay;
            }
            isRunning = false;
        }
    }
}

