using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class AssignmentUI : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Button[] taskButtons;
        [SerializeField] private Button[] memberButtons;

        private TaskData selectedTask;

        void Awake()
        {
            for (int i = 0; i < taskButtons.Length; i++)
            {
                int index = i;
                taskButtons[i].onClick.AddListener(() => OnTaskClicked(index));
            }

            for (int i = 0; i < memberButtons.Length; i++)
            {
                int index = i;
                memberButtons[i].onClick.AddListener(() => OnMemberClicked(index));
            }

            gameManager.OnTaskAssigned += HandleTaskAssigned;
            gameManager.OnTaskUnassigned += HandleTaskUnassigned;
        }

        private void OnTaskClicked(int index)
        {
            selectedTask = gameManager.Tasks[index];
        }

        private void OnMemberClicked(int index)
        {
            if (selectedTask == null) return;

            gameManager.AssignTask(selectedTask, gameManager.Members[index]);
            selectedTask = null;
        }

        private void HandleTaskAssigned(TaskData task, TeamMemberData member) => RefreshTaskColors();

        private void HandleTaskUnassigned(TaskData task) => RefreshTaskColors();

        private void RefreshTaskColors()
        {
            for (int i = 0; i < taskButtons.Length; i++)
            {
                var task = gameManager.Tasks[i];
                var member = gameManager.GetAssignment(task);
                var graphic = taskButtons[i].targetGraphic;
                if (graphic == null) continue;

                graphic.color = member == null ? gameManager.Data.UnassignedColor : member.GetRelation(task.Type) switch
                {
                    MatchQuality.Strong => gameManager.Data.StrongMatchColor,
                    MatchQuality.Neutral => gameManager.Data.NeutralMatchColor,
                    MatchQuality.Weak => gameManager.Data.WeakMatchColor,
                    _ => gameManager.Data.UnassignedColor
                };
            }
        }
    }
}
