using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class EndScreenUI : GameStateUI
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text scoreDetailText;
        [SerializeField] private TMP_Text tierText;
        [SerializeField] private TMP_Text tierDescriptionText;
        [SerializeField] private TMP_Text feedbackText;
        [SerializeField] private Button returnToStartButton;

        private GameManager gameManager;

        public override void Init(GameManager gameManager)
        {
            this.gameManager = gameManager;
            gameManager.OnDayEnded += HandleDayEnded;

            if (returnToStartButton != null)
            {
                returnToStartButton.onClick.AddListener(() => gameManager.ReturnToStart());
            }
        }

        private void HandleDayEnded(ScoreResult result)
        {
            float percent = result.MaxScore > 0f ? result.TotalScore / result.MaxScore * 100f : 0f;
            scoreText.text = $"{percent:0}%";

            if (scoreDetailText != null)
            {
                scoreDetailText.text = $"{result.TotalScore:0} / {result.MaxScore:0} points";
            }

            var tierDisplay = gameManager.Data.GetTierDisplay(result.Tier);
            tierText.text = tierDisplay != null ? tierDisplay.Label : result.Tier.ToString();

            if (tierDescriptionText != null)
            {
                tierDescriptionText.text = tierDisplay != null ? tierDisplay.Description : "";
            }

            feedbackText.text = string.Join("\n", result.FeedbackBullets);
        }
    }
}
