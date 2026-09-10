using UnityEngine;

namespace LeadershipGame
{
    [System.Serializable]
    public class TierDisplay
    {
        public ScoreTier Tier;
        public string Label;
        public string Description;
        public Color Color = Color.white;
    }
}
