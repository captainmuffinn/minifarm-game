using System;
using UnityEngine;
using TMPro;

namespace worldtime
{
    [RequireComponent(typeof(TMP_Text))]
    public class WordtimeDisplay : MonoBehaviour
    {
        [SerializeField] private DayNightCircle _worldTime;
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _worldTime.WordtimeChanged += OnWorldTimeChanged;
        }

        private void OnDestroy()
        {
            _worldTime.WordtimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            _text.SetText(newTime.ToString(@"hh\:mm"));
        }
    }
}