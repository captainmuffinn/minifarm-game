using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace worldtime
{
    [RequireComponent(typeof(Light2D))]
    public class Wordtime_light : MonoBehaviour
    {
        private Light2D _light;

        [SerializeField] private DayNightCircle _worldTime;
        [SerializeField] private Gradient _gradient;

        private void Start()
        {
            _light = GetComponent<Light2D>();
            _worldTime.WordtimeChanged += OnWorldTimeChanged;
        }

        private void OnDestroy()
        {
            _worldTime.WordtimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            float percent = PercentOfDay(newTime);
            Color newColor = _gradient.Evaluate(percent);

            Debug.Log($"Zeit: {newTime} | Prozent: {percent} | Farbe: {newColor} | Light Farbe vorher: {_light.color}");

            _light.color = newColor;

            Debug.Log($"Light Farbe nachher: {_light.color}");
        }

        private float PercentOfDay(TimeSpan timeSpan)
        {
            return (float)(timeSpan.TotalMinutes % WorldTime.MinutesInDay) / WorldTime.MinutesInDay;
        }
    }
}