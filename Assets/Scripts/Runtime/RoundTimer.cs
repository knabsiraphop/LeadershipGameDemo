using System;
using UnityEngine;

namespace LeadershipGame
{
    public class RoundTimer
    {
        public float RemainingTime { get; private set; }
        public bool IsRunning { get; private set; }

        public event Action<float> OnTick;
        public event Action OnExpired;

        public void Start(float duration)
        {
            RemainingTime = duration;
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Tick(float deltaTime)
        {
            if (!IsRunning) return;

            RemainingTime = Mathf.Max(0f, RemainingTime - deltaTime);
            OnTick?.Invoke(RemainingTime);

            if (RemainingTime <= 0f)
            {
                IsRunning = false;
                OnExpired?.Invoke();
            }
        }
    }
}
