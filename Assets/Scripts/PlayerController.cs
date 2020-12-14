using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;

    float distanceTraveled = 0;
    float endDistance;

    Vector3 movement;

    bool isDead = false;

    public static event Action<PlayerController> Win;
    public static event Action<PlayerController> Die;
    private void Start()
    {
        isDead = false;
    }
    void Update()
    {
        if (isDead)
            return;
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

    public float GetDistanceTraveled()
    {
        return distanceTraveled;
    }
    public bool GetIsDead()
    {
        return isDead;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bounce"))
        {
            movement.y *= -0.5f; // make it bounce on the top of the screen
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die?.Invoke(this);
            isDead = true;
        }
    }
    public void Respawn()
    {
        transform.position = Vector3.zero;
        distanceTraveled = endDistance;
        movement.y = 0;
        isDead = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Victory"))
        {
            distanceTraveled += transform.position.x;
            endDistance = distanceTraveled;
            Win?.Invoke(this);
        }
    }

    void OnBecameInvisible()
    {
        isDead = false;
        Die?.Invoke(this);
    }
}
