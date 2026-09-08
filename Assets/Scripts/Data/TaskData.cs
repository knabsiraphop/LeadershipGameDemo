using UnityEngine;

namespace LeadershipGame
{
    [CreateAssetMenu(fileName = "TaskData", menuName = "Delegation Dilemma/Task", order = 0)]
    public class TaskData : ScriptableObject
    {
        public string TaskName;
        public TaskType Type;
        public Urgency Urgency;
        public int Effort;
    }
}
