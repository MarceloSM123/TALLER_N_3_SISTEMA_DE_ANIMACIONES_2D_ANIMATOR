using UnityEngine;

public class playerController : MonoBehaviour
{
private Rigidbody2D rd;
    public float speed=5f;
    public float jumpForce=7f;
    private bool isGrounded;
    private Animator animator;

    private bool facingRight=true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() 
    {
                float move=Input.GetAxis("Horizontal");
                float speedAnimation=Mathf.Abs(move);
                animator.SetFloat("speed",speedAnimation);
        rd.velocity=new Vector2(move * speed, rd.velocity.y); // no se mueve en el eje y
        // salto 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rd.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            isGrounded=false;
            animator.SetBool("isJump",true);
        }   
        if(move>0 && !facingRight){
            Flip();
        }else if(move<0 && facingRight){
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
if(collision.gameObject.CompareTag("ground")){
    isGrounded=true;
    animator.SetBool("isJump",false);
}
    }

    void OnCollisionExit2D(Collision2D collision){
if(collision.gameObject.CompareTag("ground")){
    isGrounded=false;

}
    }

    void Flip(){
        facingRight=!facingRight;
        Vector3 scale=transform.localScale;
        scale.x*=-1;
        transform.localScale=scale;
    }
}
