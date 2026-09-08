using System;
using System.Collections.Generic;
using UnityEngine;

namespace LeadershipGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameData gameData;

        private readonly RoundTimer timer = new RoundTimer();
        private readonly AssignmentTracker assignmentTracker = new AssignmentTracker();

        public GameData Data => gameData;
        public IReadOnlyList<TaskData> Tasks => gameData.Content.AllTasks;
        public IReadOnlyList<TeamMemberData> Members => gameData.Content.AllMembers;

        public RoundState CurrentState { get; private set; } = RoundState.Start;
        public float RemainingTime => timer.RemainingTime;

        public event Action<RoundState> OnStateChanged;
        public event Action<float> OnTimerTick;
        public event Action<TaskData, TeamMemberData> OnTaskAssigned;
        public event Action<TaskData> OnTaskUnassigned;
        public event Action<ScoreResult> OnDayEnded;

        void Awake()
        {
            timer.OnTick += remaining => OnTimerTick?.Invoke(remaining);
            timer.OnExpired += EndDay;
            assignmentTracker.OnAssigned += (task, member) => OnTaskAssigned?.Invoke(task, member);
            assignmentTracker.OnUnassigned += task => OnTaskUnassigned?.Invoke(task);
        }

        void Update()
        {
            if (IsIn(RoundState.Round))
            {
                timer.Tick(Time.deltaTime);
            }
        }

        public void StartDay()
        {
            if (!IsIn(RoundState.Start)) return;

            assignmentTracker.Clear();
            timer.Start(gameData.Balance.RoundDuration);
            SetState(RoundState.Round);
        }

        public void AssignTask(TaskData task, TeamMemberData member)
        {
            if (!IsIn(RoundState.Round)) return;
            assignmentTracker.Assign(task, member);
        }

        public void UnassignTask(TaskData task)
        {
            if (!IsIn(RoundState.Round)) return;
            assignmentTracker.Unassign(task);
        }

        public TeamMemberData GetAssignment(TaskData task) => assignmentTracker.GetAssignment(task);

        public bool IsAssigned(TaskData task) => assignmentTracker.IsAssigned(task);

        public int GetAssignedEffort(TeamMemberData member) => assignmentTracker.GetAssignedEffort(member);

        public bool IsOverCapacity(TeamMemberData member) => assignmentTracker.IsOverCapacity(member);

        public void EndDay()
        {
            if (!IsIn(RoundState.Round)) return;

            ScoreResult result = ScoreCalculator.Calculate(
                assignmentTracker.Current,
                gameData.Content.AllTasks,
                gameData.Content.AllMembers,
                gameData.Balance);

            timer.Stop();
            SetState(RoundState.End);
            OnDayEnded?.Invoke(result);
        }

        private bool IsIn(RoundState state) => CurrentState == state;

        private void SetState(RoundState next)
        {
            CurrentState = next;
            OnStateChanged?.Invoke(CurrentState);
        }
    }
}
