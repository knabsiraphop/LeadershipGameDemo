using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeadershipGame
{
    public class LegendSwatch : MonoBehaviour
    {
        [SerializeField] private Image swatchImage;
        [SerializeField] private TMP_Text label;

        public void Set(Color color, string text)
        {
            swatchImage.color = color;
            label.text = text;
        }
    }
}
