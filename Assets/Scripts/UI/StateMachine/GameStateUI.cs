using UnityEngine;

namespace LeadershipGame
{
    public abstract class GameStateUI : MonoBehaviour
    {
        public abstract void Init(GameManager gameManager);

        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}
