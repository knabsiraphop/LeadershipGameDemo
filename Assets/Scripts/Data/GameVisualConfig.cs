using System.Collections.Generic;
using UnityEngine;

namespace LeadershipGame
{
    [CreateAssetMenu(fileName = "GameVisualConfig", menuName = "Delegation Dilemma/Visual Config", order = 2)]
    public class GameVisualConfig : ScriptableObject
    {
        [SerializeField] private List<MatchQualityColor> matchColors;
        [SerializeField] private Color unassignedColor = Color.white;
        [SerializeField] private List<TierDisplay> tierDisplays;

        public IReadOnlyList<MatchQualityColor> MatchColors => matchColors;
        public Color UnassignedColor => unassignedColor;

        public Color GetColor(MatchQuality quality)
        {
            foreach (var entry in matchColors)
            {
                if (entry.Quality == quality) return entry.Color;
            }

            return unassignedColor;
        }

        public TierDisplay GetTierDisplay(ScoreTier tier)
        {
            foreach (var entry in tierDisplays)
            {
                if (entry.Tier == tier) return entry;
            }

            return null;
        }
    }
}
