using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace worldtime
{
    [RequireComponent(typeof(Light2D))]
    public class Wordtime_light : MonoBehaviour
    {
         private Light2D _light;

        [SerializeField] private Gradient _gradient;

        private void Start()
        {
            _light = GetComponent<Light2D>();
            DayNightCircle.Instance.WordtimeChanged += OnWorldTimeChanged;
            OnWorldTimeChanged(this, DayNightCircle.Instance.CurrentTime);
        }

        private void OnDestroy()
        {
            DayNightCircle.Instance.WordtimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            float percent = PercentOfDay(newTime);
            Color newColor = _gradient.Evaluate(percent);


            _light.color = newColor;

        }

        private float PercentOfDay(TimeSpan timeSpan)
        {
            return (float)(timeSpan.TotalMinutes % WorldTime.MinutesInDay) / WorldTime.MinutesInDay;
        }
    }
}