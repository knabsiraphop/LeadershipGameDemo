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

        public Button Button => button;

        public void Set(TaskData task)
        {
            label.text = task.TaskName;

            if (detailText != null)
            {
                detailText.text = $"{task.Type} · {task.Urgency} urgency · {task.Effort} effort";
            }
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
