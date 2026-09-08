using UnityEngine;

namespace LeadershipGame
{
    [CreateAssetMenu(fileName = "TeamMemberData", menuName = "Delegation Dilemma/Team Member", order = 1)]
    public class TeamMemberData : ScriptableObject
    {
        public string MemberName;
        public TaskType StrongType;
        public TaskType WeakType;
        public int Capacity = 4;

        public MatchQuality GetRelation(TaskType taskType)
        {
            if (taskType == StrongType) return MatchQuality.Strong;
            if (taskType == WeakType) return MatchQuality.Weak;
            return MatchQuality.Neutral;
        }
    }
}
