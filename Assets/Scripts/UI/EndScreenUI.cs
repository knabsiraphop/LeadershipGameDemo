using TMPro;
using UnityEngine;

namespace LeadershipGame
{
    public class EndScreenUI : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text tierText;
        [SerializeField] private TMP_Text feedbackText;

        void Awake()
        {
            gameManager.OnDayEnded += HandleDayEnded;
        }

        private void HandleDayEnded(ScoreResult result)
        {
            float percent = result.MaxScore > 0f ? result.TotalScore / result.MaxScore * 100f : 0f;
            scoreText.text = $"{percent:0}%";
            tierText.text = result.Tier.ToString();
            feedbackText.text = string.Join("\n", result.FeedbackBullets);
        }
    }
}
