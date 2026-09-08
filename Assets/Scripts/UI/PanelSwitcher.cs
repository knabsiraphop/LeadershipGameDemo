using UnityEngine;

namespace LeadershipGame
{
    public class PanelSwitcher : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject roundPanel;
        [SerializeField] private GameObject endPanel;

        void Awake()
        {
            gameManager.OnStateChanged += HandleStateChanged;
            HandleStateChanged(gameManager.CurrentState);
        }

        private void HandleStateChanged(RoundState state)
        {
            startPanel.SetActive(state == RoundState.Start);
            roundPanel.SetActive(state == RoundState.Round);
            endPanel.SetActive(state == RoundState.End);
        }
    }
}
