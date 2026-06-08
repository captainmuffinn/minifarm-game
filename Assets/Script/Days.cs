using UnityEngine;
using TMPro;
using worldtime;

public class DayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;

    void Update()
    {
        if (DayNightCircle.Instance == null) return;
        dayText.text = "Tag " + DayNightCircle.Instance.CurrentDay;
    }
}