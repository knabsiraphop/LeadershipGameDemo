using System.Collections.Generic;
using UnityEngine;

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
        private const float HighPoints = 3f;
        private const float MediumPoints = 2f;
        private const float LowPoints = 1f;
        private const float FailedPoints = 0f;

        public static ScoreResult Calculate(
            IReadOnlyDictionary<TaskData, TeamMemberData> assignments,
            IReadOnlyList<TaskData> allTasks,
            IReadOnlyList<TeamMemberData> allMembers,
            GameBalanceConfig balance)
        {
            var effortByMember = GetEffortByMember(assignments, allMembers);

            float total = 0f;
            float max = 0f;

            TaskData bestHighTask = null;
            float bestHighWeight = -1f;

            TaskData failedTask = null;

            TaskData worstWeakTask = null;
            float worstWeakWeight = -1f;

            foreach (var task in allTasks)
            {
                float weight = balance.GetUrgencyWeight(task.Urgency);
                max += HighPoints * weight;

                if (!assignments.TryGetValue(task, out var member) || member == null)
                {
                    failedTask ??= task;
                    continue;
                }

                MatchQuality relation = member.GetRelation(task.Type);
                float points = BasePoints(relation);

                bool burnedOut = effortByMember[member] > member.Capacity;
                if (burnedOut)
                {
                    points = Mathf.Max(LowPoints, points - 1f);
                }

                total += points * weight;

                if (points >= HighPoints && weight > bestHighWeight)
                {
                    bestHighWeight = weight;
                    bestHighTask = task;
                }

                if (relation == MatchQuality.Weak && weight > worstWeakWeight)
                {
                    worstWeakWeight = weight;
                    worstWeakTask = task;
                }
            }

            float percent = max > 0f ? total / max : 0f;
            ScoreTier tier = percent >= balance.StrongDelegatorCutoff ? ScoreTier.StrongDelegator
                : percent >= balance.DevelopingCutoff ? ScoreTier.Developing
                : ScoreTier.OverloadedManager;

            TeamMemberData burnedOutMember = null;
            foreach (var member in allMembers)
            {
                if (effortByMember[member] > member.Capacity)
                {
                    burnedOutMember = member;
                    break;
                }
            }

            var bullets = BuildFeedback(bestHighTask, failedTask, burnedOutMember, effortByMember, worstWeakTask, tier);

            return new ScoreResult
            {
                TotalScore = total,
                MaxScore = max,
                Tier = tier,
                FeedbackBullets = bullets
            };
        }

        private static float BasePoints(MatchQuality quality) => quality switch
        {
            MatchQuality.Strong => HighPoints,
            MatchQuality.Neutral => MediumPoints,
            MatchQuality.Weak => LowPoints,
            _ => FailedPoints
        };

        private static Dictionary<TeamMemberData, int> GetEffortByMember(
            IReadOnlyDictionary<TaskData, TeamMemberData> assignments,
            IReadOnlyList<TeamMemberData> allMembers)
        {
            var effort = new Dictionary<TeamMemberData, int>();
            foreach (var member in allMembers)
            {
                effort[member] = 0;
            }

            foreach (var pair in assignments)
            {
                if (pair.Value != null && effort.ContainsKey(pair.Value))
                {
                    effort[pair.Value] += pair.Key.Effort;
                }
            }

            return effort;
        }

        private static string[] BuildFeedback(
            TaskData bestHighTask,
            TaskData failedTask,
            TeamMemberData burnedOutMember,
            Dictionary<TeamMemberData, int> effortByMember,
            TaskData worstWeakTask,
            ScoreTier tier)
        {
            var bullets = new List<string>();

            bullets.Add(bestHighTask != null
                ? $"\"{bestHighTask.TaskName}\" was matched to the right strength — well delegated."
                : "No task landed a strong-fit match this round.");

            if (failedTask != null)
            {
                bullets.Add($"\"{failedTask.TaskName}\" was never assigned — an unassigned task always scores worse than a bad assignment.");
            }
            else if (burnedOutMember != null)
            {
                bullets.Add($"{burnedOutMember.MemberName} was overloaded ({effortByMember[burnedOutMember]}/{burnedOutMember.Capacity}) — their tasks lost quality from burnout.");
            }
            else if (worstWeakTask != null)
            {
                bullets.Add($"\"{worstWeakTask.TaskName}\" went to a weak-fit member — worth reassigning next time.");
            }
            else
            {
                bullets.Add("Every task found a solid fit.");
            }

            if (tier == ScoreTier.StrongDelegator)
            {
                bullets.Add("You protected capacity while still hitting priorities.");
            }
            else if (tier == ScoreTier.OverloadedManager)
            {
                bullets.Add("Too many tasks were mismatched or piled onto one person.");
            }

            return bullets.ToArray();
        }
    }
}
