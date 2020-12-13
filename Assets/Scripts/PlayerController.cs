using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;

    Vector3 movement;
    Vector3 jump;
    void Start()
    {
    }

    void Update()
    {
        Inputs();
        Mathf.Clamp(movement.y, -20,10);
        movement = new Vector3(speed, movement.y, transform.position.z);
        movement.y -= gravity * Time.deltaTime;
        transform.position += movement * Time.deltaTime; 
    }
    void Inputs()
    {
        
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.y = jumpForce;
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
             movement.y = jumpForce;
        }
#endif
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bounce"))
        {
            movement.y *= -0.5f; // make it bounce on the top of the screen
        }
    }

    void OnBecameInvisible()
    {
        //murio xd
    }
}
