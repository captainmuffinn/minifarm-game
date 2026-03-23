using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueFunktion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToGameScene()
    {

        SceneManager.LoadScene("Game");

    }

    public void Quit()
    {
        Application.Quit();
    }

}
