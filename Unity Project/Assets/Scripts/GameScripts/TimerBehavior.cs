using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace FirstProject
{
    public class TimerBehavior : MonoBehaviour
    {
        public bool looping;
        public float time;
        private float _timer;

        public UnityEvent onTimerFinished = new UnityEvent();

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= time)
            {
                onTimerFinished?.Invoke();
                if (looping)
                    _timer = 0;
                else
                    Destroy(this);
            }
        }
    }
}
