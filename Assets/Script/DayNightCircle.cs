using System;
using System.Collections;
using UnityEngine;

namespace worldtime
{
    public class DayNightCircle : MonoBehaviour
    {
        public event EventHandler<TimeSpan> WordtimeChanged;

        [SerializeField] private float _dayLength = 120f; // Sekunden pro Spieltag
        [SerializeField] private float _startHour = 6f;   // Startzeit (6 = 06:00 Uhr)

        private TimeSpan _currentTime;
        private float _minuteLength => _dayLength / WorldTime.MinutesInDay;

        void Start()
        {
            _currentTime = TimeSpan.FromHours(_startHour);
            WordtimeChanged?.Invoke(this, _currentTime); // Startwert sofort senden
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()
        {
            yield return new WaitForSeconds(_minuteLength); // Erst warten...
            _currentTime += TimeSpan.FromMinutes(1);        // ...dann addieren
            WordtimeChanged?.Invoke(this, _currentTime);
            StartCoroutine(AddMinute());
        }
    }
}