using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class TaskButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text label;
        [SerializeField] private TMP_Text detailText;
        [SerializeField] private GameObject selectionHighlight;

        private TaskData task;

        public Button Button => button;

        public void Set(TaskData task)
        {
            this.task = task;
            label.text = task.TaskName;
            SetAssignedMember(null);
        }

        public void SetAssignedMember(TeamMemberData member)
        {
            if (detailText == null || task == null) return;

            detailText.text = member == null
                ? $"{task.Type} · {task.Urgency} urgency · {task.Effort} effort"
                : $"Assigned to {member.MemberName}";
        }

        public void SetSelected(bool selected)
        {
            if (selectionHighlight != null)
            {
                selectionHighlight.SetActive(selected);
            }
        }
    }
}
