using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class StartUI : GameStateUI
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Toggle colorGuideToggle;

        private GameManager gameManager;

        void Awake()
        {
            startButton.onClick.AddListener(() =>
            {
                if (colorGuideToggle != null)
                {
                    gameManager.ColorGuideEnabled = colorGuideToggle.isOn;
                }

                gameManager.StartDay();
            });
        }

        public override void Init(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }
    }
}
