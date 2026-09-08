using UnityEngine;

namespace LeadershipGame
{
    public class GameData : MonoBehaviour
    {
        [SerializeField] private GameContentConfig content;
        [SerializeField] private GameBalanceConfig balance;

        [SerializeField] private Color strongMatchColor = Color.green;
        [SerializeField] private Color neutralMatchColor = Color.yellow;
        [SerializeField] private Color weakMatchColor = Color.red;
        [SerializeField] private Color unassignedColor = Color.white;

        public GameContentConfig Content => content;
        public GameBalanceConfig Balance => balance;

        public Color StrongMatchColor => strongMatchColor;
        public Color NeutralMatchColor => neutralMatchColor;
        public Color WeakMatchColor => weakMatchColor;
        public Color UnassignedColor => unassignedColor;
    }
}
