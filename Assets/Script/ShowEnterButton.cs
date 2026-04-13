using UnityEngine;

public class ShowEnterButton : MonoBehaviour
{
    public GameObject enterButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            enterButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            enterButton.SetActive(false);
    }
}
