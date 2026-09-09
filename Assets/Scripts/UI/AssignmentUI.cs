using System.Collections.Generic;
using KidzDev.Unity.SlicedFillImage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class AssignmentUI : GameStateUI
    {
        [SerializeField] private TaskButton taskButtonPrefab;
        [SerializeField] private Transform taskContainer;
        [SerializeField] private MemberButton memberButtonPrefab;
        [SerializeField] private Transform memberContainer;
        [Space]
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private SlicedFilledImage timerFill;
        [SerializeField] private Button endDayButton;
        [Space]
        [SerializeField] private LegendSwatch legendSwatchPrefab;
        [SerializeField] private Transform legendContainer;

        private GameManager gameManager;
        private TaskData selectedTask;
        private readonly Dictionary<TaskData, TaskButton> taskButtons = new Dictionary<TaskData, TaskButton>();

        public override void Init(GameManager gameManager)
        {
            this.gameManager = gameManager;

            SpawnTaskButtons();
            SpawnMemberButtons();
            SpawnLegend();
            BindEvents();

            RefreshTaskColors();
            HandleTimerTick(gameManager.Data.Balance.RoundDuration);
        }

        private void SpawnTaskButtons()
        {
            foreach (var task in gameManager.Tasks)
            {
                var taskButton = Instantiate(taskButtonPrefab, taskContainer);
                taskButton.Set(task);
                taskButton.Button.onClick.AddListener(() => OnTaskClicked(task));
                taskButtons[task] = taskButton;
            }
        }

        private void SpawnMemberButtons()
        {
            foreach (var member in gameManager.Members)
            {
                var memberButton = Instantiate(memberButtonPrefab, memberContainer);
                memberButton.Set(member);
                memberButton.Button.onClick.AddListener(() => OnMemberClicked(member));
            }
        }

        private void SpawnLegend()
        {
            foreach (var entry in gameManager.Data.MatchColors)
            {
                Instantiate(legendSwatchPrefab, legendContainer).Set(entry.Color, entry.Label);
            }
        }

        private void BindEvents()
        {
            endDayButton.onClick.AddListener(() => gameManager.EndDay());
            gameManager.OnTaskAssigned += HandleTaskAssigned;
            gameManager.OnTaskUnassigned += HandleTaskUnassigned;
            gameManager.OnTimerTick += HandleTimerTick;
        }

        private void OnTaskClicked(TaskData task)
        {
            selectedTask = task;
        }

        private void OnMemberClicked(TeamMemberData member)
        {
            if (selectedTask == null) return;

            gameManager.AssignTask(selectedTask, member);
            selectedTask = null;
        }

        private void HandleTaskAssigned(TaskData task, TeamMemberData member) => RefreshTaskColors();

        private void HandleTaskUnassigned(TaskData task) => RefreshTaskColors();

        private void HandleTimerTick(float remaining)
        {
            int seconds = Mathf.CeilToInt(Mathf.Max(0f, remaining));
            timerText.text = $"{seconds / 60:00}:{seconds % 60:00}";
            timerFill.fillAmount = gameManager.Data.Balance.RoundDuration > 0f
                ? remaining / gameManager.Data.Balance.RoundDuration
                : 0f;
        }

        private void RefreshTaskColors()
        {
            foreach (var pair in taskButtons)
            {
                var task = pair.Key;
                var member = gameManager.GetAssignment(task);
                var graphic = pair.Value.Button.targetGraphic;
                if (graphic == null) continue;

                graphic.color = member == null
                    ? gameManager.Data.UnassignedColor
                    : gameManager.Data.GetMatchColor(member.GetRelation(task.Type));
            }
        }
    }
}
