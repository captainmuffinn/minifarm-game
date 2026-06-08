using System;
using System.Collections;
using UnityEngine;

namespace worldtime
{
    public class DayNightCircle : MonoBehaviour
    {
        public TimeSpan CurrentTime => _currentTime;
        public static DayNightCircle Instance;

        private int _currentDay = 1;
        public int CurrentDay => _currentDay;


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
        public event EventHandler<TimeSpan> WordtimeChanged;

        [SerializeField] private float _dayLength = 120f;
        [SerializeField] private float _startHour = 6f;

        private TimeSpan _currentTime;
        private float _minuteLength => _dayLength / WorldTime.MinutesInDay;

        void Start()
        {
            _currentTime = TimeSpan.FromHours(_startHour);
            WordtimeChanged?.Invoke(this, _currentTime);
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()
        {
            yield return new WaitForSeconds(_minuteLength);
            _currentTime += TimeSpan.FromMinutes(1);
            WordtimeChanged?.Invoke(this, _currentTime);
            StartCoroutine(AddMinute());
        }
        public string GetTimeString()
        {
            
            return _currentTime.Hours.ToString("00") + ":" + _currentTime.Minutes.ToString("00");
        }

        public void ResetToMorning()
        {
            _currentDay++;
            _currentTime = TimeSpan.FromHours(_startHour);
            WordtimeChanged?.Invoke(this, _currentTime);
            FlowerManager.Instance.GrowAll();
        }
    }
}