using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using worldtime;


namespace worldtime
{
    public class WorldTimeWatcher : MonoBehaviour
    {
        [SerializeField] private DayNightCircle _worldTime;
        
        [SerializeField] private List<sheulde> _sheulde;
        private void Start()
        {
            _worldTime.WordtimeChanged += CheckSheulde;

        }

        private void OnDestroy()
        {
            _worldTime.WordtimeChanged -= CheckSheulde;

        }

        private void CheckSheulde (object sender,TimeSpan newTime)
        {
            var sheulde = _sheulde.FirstOrDefault(s =>
                s.hour == newTime.Hours &&
                s.minute == newTime.Minutes);

            sheulde?._action?.Invoke();
        }

        [Serializable]
        private class sheulde
        {
            public int hour;
            public int minute;
            public UnityEvent _action ;
        }
    }
}