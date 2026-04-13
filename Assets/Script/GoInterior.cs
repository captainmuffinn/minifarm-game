using UnityEngine;
using UnityEngine.SceneManagement;

public class GoInterior : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Interior");
    }
}