using UnityEngine;

namespace LeadershipGame
{
    [CreateAssetMenu(fileName = "GameBalanceConfig", menuName = "Delegation Dilemma/Game Balance Config", order = 2)]
    public class GameBalanceConfig : ScriptableObject
    {
        [Header("Round")]
        public float RoundDuration = 90f;

        [Header("Urgency Weights")]
        public float HighUrgencyWeight = 2f;
        public float MedUrgencyWeight = 1.5f;
        public float LowUrgencyWeight = 1f;

        [Header("Score Tier Cutoffs (fraction of max score)")]
        [Range(0f, 1f)] public float StrongDelegatorCutoff = 0.85f;
        [Range(0f, 1f)] public float DevelopingCutoff = 0.50f;

        public float GetUrgencyWeight(Urgency urgency) => urgency switch
        {
            Urgency.High => HighUrgencyWeight,
            Urgency.Med => MedUrgencyWeight,
            Urgency.Low => LowUrgencyWeight,
            _ => 1f
        };
    }
}
