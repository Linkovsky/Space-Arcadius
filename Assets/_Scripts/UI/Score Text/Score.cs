using System;
using TMPro;
using UnityEngine;

namespace Arcade.UI.Score
{
    [DefaultExecutionOrder(-1)]
    public class Score : MonoBehaviour
    {
        public static Score instance;

        private TextMeshProUGUI scoreText;
        private int scoreValue;

        private void Awake()
        {
            instance = this;
            scoreText = GetComponentInChildren<TextMeshProUGUI>();
            scoreText.text = "Score: " + scoreValue.ToString();
        }

        public void AddScore(int amount)
        {
            scoreValue += amount;
            UpdateUIText();
        }

        public void UpdateUIText()
        {
            scoreText.text = "Score: " + scoreValue.ToString();
        }
    }
}