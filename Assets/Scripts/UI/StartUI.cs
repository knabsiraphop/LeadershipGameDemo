using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class StartUI : GameStateUI
    {
        [SerializeField] private Button startButton;

        private GameManager gameManager;

        void Awake()
        {
            startButton.onClick.AddListener(() => gameManager.StartDay());
        }

        public override void Init(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }
    }
}
