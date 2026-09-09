using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class MemberButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text label;
        [SerializeField] private TMP_Text detailText;
        [SerializeField] private Image matchPreviewImage;
        [SerializeField] private Color noPreviewColor = Color.white;

        private TeamMemberData member;

        public Button Button => button;

        public void Set(TeamMemberData member)
        {
            this.member = member;
            label.text = member.MemberName;

            if (detailText != null)
            {
                detailText.text = $"Strong: {member.StrongType} · Weak: {member.WeakType}";
            }
        }

        public void SetLoad(int assignedEffort, bool overCapacity)
        {
            if (detailText == null || member == null) return;

            detailText.text = $"Strong: {member.StrongType} · Weak: {member.WeakType}\n" +
                $"Load: {assignedEffort}/{member.Capacity}" + (overCapacity ? " (over capacity)" : "");
        }

        public void SetMatchPreview(Color? color)
        {
            if (matchPreviewImage == null) return;
            matchPreviewImage.color = color ?? noPreviewColor;
        }
    }
}
