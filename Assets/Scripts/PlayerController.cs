using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float jumpForce;

    Vector3 movement;

    void Start()
    {
        
    }

    void Update()
    {
        movement = new Vector3(speed, transform.position.y, transform.position.z);
        transform.position += movement * Time.deltaTime;
    }
}
