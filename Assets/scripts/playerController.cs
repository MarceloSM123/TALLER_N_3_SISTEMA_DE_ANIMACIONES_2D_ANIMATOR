using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rd;
    public float speed=5f;
    public float jumpForce=7f;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd=GetComponent<Rigidbody2D>();// se lo ejecuta 1 sola vez
    }

    // Update is called once per frame
    void Update()
    {
        float move=Input.GetAxis("Horizontal");
        rd.velocity=new Vector2(move * speed, rd.velocity.y); // no se mueve en el eje y
        // salto 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
rd.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
isGrounded=false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
if(collision.gameObject.CompareTag("ground")){
    isGrounded=true;
}
    }
}
