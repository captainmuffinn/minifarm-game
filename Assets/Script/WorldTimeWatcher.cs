using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace worldtime
{
    public class WorldTimeWatcher : MonoBehaviour
    {

        public static WorldTimeWatcher Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        [SerializeField] private DayNightCircle _worldTime;

        [SerializeField] private List<Sheulde> _sheulde;

        private int _lastHour = -1;
        private int _lastMinute = -1;

        private void Start()
        {
            if (_worldTime == null)
                _worldTime = DayNightCircle.Instance;

            _worldTime.WordtimeChanged += CheckSheulde;
        }

        private void OnDestroy()
        {
            _worldTime.WordtimeChanged -= CheckSheulde;
        }

        private void CheckSheulde(object sender, TimeSpan newTime)
        {
            if (_lastHour == newTime.Hours &&
                _lastMinute == newTime.Minutes)
                return;

            _lastHour = newTime.Hours;
            _lastMinute = newTime.Minutes;

            var sheulde = _sheulde.FirstOrDefault(s =>
                s.hour == newTime.Hours &&
                s.minute == newTime.Minutes);

            sheulde?._action?.Invoke();
        }

        [Serializable]
        private class Sheulde
        {
            public int hour;
            public int minute;
            public UnityEvent _action;
        }
    }
}