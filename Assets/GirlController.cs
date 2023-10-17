using UnityEngine;

public class GirlController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var axis = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * (axis * speed * Time.deltaTime));
    }
}