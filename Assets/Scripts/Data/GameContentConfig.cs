using System.Collections.Generic;
using UnityEngine;

namespace LeadershipGame
{
    [CreateAssetMenu(fileName = "GameContentConfig", menuName = "Delegation Dilemma/Game Content Config", order = 3)]
    public class GameContentConfig : ScriptableObject
    {
        [Tooltip("Order matters -- must match the order UI buttons are wired in AssignmentUI (index 0 = first task button, etc).")]
        public List<TaskData> AllTasks = new List<TaskData>();

        [Tooltip("Order matters -- must match the order UI buttons are wired in AssignmentUI (index 0 = first member button, etc).")]
        public List<TeamMemberData> AllMembers = new List<TeamMemberData>();
    }
}
