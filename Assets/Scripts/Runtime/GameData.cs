using System.Collections.Generic;
using UnityEngine;

namespace LeadershipGame
{
    public class GameData : MonoBehaviour
    {
        [SerializeField] private GameContentConfig content;
        [SerializeField] private GameBalanceConfig balance;
        [SerializeField] private GameVisualConfig visual;

        public GameContentConfig Content => content;
        public GameBalanceConfig Balance => balance;

        public IReadOnlyList<MatchQualityColor> MatchColors => visual.MatchColors;
        public Color UnassignedColor => visual.UnassignedColor;

        public Color GetMatchColor(MatchQuality quality) => visual.GetColor(quality);

        public TierDisplay GetTierDisplay(ScoreTier tier) => visual.GetTierDisplay(tier);
    }
}
