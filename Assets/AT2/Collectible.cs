using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    private Menu _menu;
    public int score;
    public UnityEvent onCollect;

    private void Awake()
    {
        _menu = FindObjectOfType<Menu>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _menu.AddScore(score);
            onCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}