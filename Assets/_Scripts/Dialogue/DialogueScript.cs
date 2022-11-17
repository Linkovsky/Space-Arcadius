using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcade.Dialogue
{
    [CreateAssetMenu( fileName = "Dialogue Asset", menuName = "New Dialogue", order = 52)]
    public class DialogueScript : ScriptableObject
    {
        [field: SerializeField, TextArea(1,200)] public string[] Text { get; set; }
    }
}

