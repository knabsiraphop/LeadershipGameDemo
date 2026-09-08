using UnityEngine;

namespace LeadershipGame
{
    public class GameData : MonoBehaviour
    {
        [SerializeField] private GameContentConfig content;
        [SerializeField] private GameBalanceConfig balance;

        public GameContentConfig Content => content;
        public GameBalanceConfig Balance => balance;
    }
}
