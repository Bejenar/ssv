using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    public int startingPoint;

    public Transform[] points;

    public bool isDestroyable;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.2f)
        {
            if (++i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            points[i].position,
            speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            if (isDestroyable)
            {
                Invoke(nameof(Destruct), 2f);
                isDestroyable = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    private void Destruct()
    {
        Destroy(gameObject);
    }
}