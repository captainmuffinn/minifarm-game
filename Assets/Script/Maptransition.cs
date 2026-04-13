using Cinemachine;
using UnityEngine;

public class Maptransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner confiner;
    [SerializeField] Direction direction;
    [SerializeField] float additivePos= -2f;
    enum Direction { Up,Down,Left,Right}
    private void Awake()
    {
        confiner = FindObjectOfType<CinemachineConfiner>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.m_BoundingShape2D = mapBoundry;
            confiner.InvalidatePathCache(); // <-- das ist der wichtigste Fix!
        }
    }

}
