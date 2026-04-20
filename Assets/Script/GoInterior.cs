using UnityEngine;
using UnityEngine.SceneManagement;

public class GoInterior : MonoBehaviour
{
        public void GoToInterior()
        {
            SceneManager.LoadScene("Interior");
        }

        public void GoToGame()
        {
            SceneManager.LoadScene("Game");
        }

}