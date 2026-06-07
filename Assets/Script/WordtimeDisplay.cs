using UnityEngine;
using TMPro;
using worldtime;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    void Update()
    {
        if (DayNightCircle.Instance == null) return;
        timeText.text = DayNightCircle.Instance.GetTimeString();
    }
}