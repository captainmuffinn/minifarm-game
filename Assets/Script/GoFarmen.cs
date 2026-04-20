using UnityEngine;
using UnityEngine.SceneManagement;

public class GoFarmen : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Farmen");
    }
}
