using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class MemberButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text label;

        public Button Button => button;

        public void Set(TeamMemberData member)
        {
            label.text = member.MemberName;
        }
    }
}
