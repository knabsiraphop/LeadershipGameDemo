using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class TaskButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text label;

        public Button Button => button;

        public void Set(TaskData task)
        {
            label.text = task.TaskName;
        }
    }
}
