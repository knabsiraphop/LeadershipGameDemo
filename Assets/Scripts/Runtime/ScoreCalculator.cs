using System.Collections.Generic;

namespace LeadershipGame
{
    public class ScoreResult
    {
        public float TotalScore;
        public float MaxScore;
        public ScoreTier Tier;
        public string[] FeedbackBullets;
    }

    public static class ScoreCalculator
    {
        public static ScoreResult Calculate(
            IReadOnlyDictionary<TaskData, TeamMemberData> assignments,
            IReadOnlyList<TaskData> allTasks,
            IReadOnlyList<TeamMemberData> allMembers,
            GameBalanceConfig balance)
        {
            return new ScoreResult
            {
                TotalScore = 0f,
                MaxScore = 1f,
                Tier = ScoreTier.Developing,
                FeedbackBullets = new[] { "placeholder" }
            };
        }
    }
}
