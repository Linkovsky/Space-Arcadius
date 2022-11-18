using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arcade.Dialogue
{
    public class Dialogue : MonoBehaviour
    {
        public static Dialogue Instance { get; }
        
        [SerializeField] private Image speakerIcon;
        private TextMeshProUGUI text;
        private WaitForSeconds charDelay;
        
        private bool isRunning = false;
        private string dialogue;
        
        private void Awake()
        {
            charDelay = new WaitForSeconds(0.05f);
            text = GetComponentInChildren<TextMeshProUGUI>();
            text.text = "";
        }
        
        public IEnumerator ReceiveDialogueAsset(DialogueScript dialogueText)
        {
            speakerIcon.sprite = dialogueText.icon;
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

