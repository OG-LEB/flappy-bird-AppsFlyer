using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float jumpForce;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {

        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    public void Activate() 
    {
        Time.timeScale = 1f;
        _rigidbody2D.isKinematic = false;
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        transform.position = Vector3.zero;
        _rigidbody2D.isKinematic = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead Collider"))
        {
            gameObject.SetActive(false);
            GameManager.GetInstance().GameOver();
        }
    }
}
