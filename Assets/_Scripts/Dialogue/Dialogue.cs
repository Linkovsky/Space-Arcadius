using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Arcade.Dialogue;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Arcade.Dialogue
{
    public class Dialogue : MonoBehaviour
    {
        public static Dialogue Instance { get; }

        private TextMeshProUGUI text;
        private WaitForSeconds charDelay;
        private bool isRunning = false;
        private string dialogue;
        private void Awake()
        {
            charDelay = new WaitForSeconds(0.1f);
            text = GetComponent<TextMeshProUGUI>();
            text.text = "";
        }
    
        public IEnumerator ReceiveDialogue(DialogueScript dialogueText)
        {
            foreach (var t in dialogueText.Text)
            {
                text.text = "";
                dialogue = t;
                isRunning = true;
                yield return StartCoroutine(StartDialogue());
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
                }
        }
    
        private IEnumerator StartDialogue()
        {
            int i = 0;
            while (isRunning)
            {
                if (i < dialogue.Last())
                {
                    text.text += dialogue[i].ToString();
                    i++;
                    yield return charDelay;
                }
                else
                    isRunning = false;
            }
        }
    }
}

