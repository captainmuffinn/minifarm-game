using UnityEngine;
using worldtime;

public class Bed : MonoBehaviour
{
    public void Sleep()
    {
        DayNightCircle.Instance.ResetToMorning();
    }
}