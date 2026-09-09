using System.Collections.Generic;
using UnityEngine;

namespace LeadershipGame
{
    public class GameStateController : MonoBehaviour, IGameStateController
    {
        [SerializeField] private StartUI startUI;
        [SerializeField] private AssignmentUI roundUI;
        [SerializeField] private EndScreenUI endUI;

        private Dictionary<RoundState, GameStateUI> states;
        private GameStateUI current;

        public void Init(GameManager gameManager)
        {
            states = new Dictionary<RoundState, GameStateUI>
            {
                { RoundState.Start, startUI },
                { RoundState.Round, roundUI },
                { RoundState.End, endUI },
            };

            foreach (var state in states.Values)
            {
                state.Init(gameManager);
            }

            gameManager.OnStateChanged += HandleStateChanged;
            HandleStateChanged(gameManager.CurrentState);
        }

        private void HandleStateChanged(RoundState state)
        {
            current?.Hide();
            current = states[state];
            current.Show();
        }
    }
}
