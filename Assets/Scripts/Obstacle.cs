using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Camera cam;
    [SerializeField] float speed;
    Vector3 direction = Vector3.left;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (transform.position.x < cam.ViewportToWorldPoint(Vector3.zero).x)
        {
            gameObject.SetActive(false);
        }
    }
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);    
    }
}
