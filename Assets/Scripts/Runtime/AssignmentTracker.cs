using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadershipGame
{
    public class AssignmentTracker
    {
        private readonly Dictionary<TaskData, TeamMemberData> assignments = new Dictionary<TaskData, TeamMemberData>();

        public IReadOnlyDictionary<TaskData, TeamMemberData> Current => assignments;

        public event Action<TaskData, TeamMemberData> OnAssigned;
        public event Action<TaskData> OnUnassigned;

        public void Clear() => assignments.Clear();

        public void Assign(TaskData task, TeamMemberData member)
        {
            assignments[task] = member;
            OnAssigned?.Invoke(task, member);
        }

        public bool Unassign(TaskData task)
        {
            if (!assignments.Remove(task)) return false;

            OnUnassigned?.Invoke(task);
            return true;
        }

        public TeamMemberData GetAssignment(TaskData task)
        {
            return assignments.TryGetValue(task, out var member) ? member : null;
        }

        public bool IsAssigned(TaskData task) => assignments.ContainsKey(task);

        public int GetAssignedEffort(TeamMemberData member)
        {
            return assignments.Where(a => a.Value == member).Sum(a => a.Key.Effort);
        }

        public bool IsOverCapacity(TeamMemberData member)
        {
            return GetAssignedEffort(member) > member.Capacity;
        }
    }
}
