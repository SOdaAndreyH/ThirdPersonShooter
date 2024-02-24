using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Animator;
    public float Speed = 5f;
    public float JumpHeight = 3f;
    public float Gravity = -9.81f;    

    Vector3 _velocity;
    CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _velocity.x = horizontal * Speed;
        _velocity.z = vertical * Speed;
        
        if (horizontal != 0 || vertical != 0)
        {
            Animator.SetBool("isRun", true);
        }
        else
        {
            Animator.SetBool("isRun", false);
        }

        //vertical movement
        if (_controller.isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -1f;
           Animator.SetBool("isGrounded", true);
        }
        _velocity.y += Gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && _controller.isGrounded)
        {
            _velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            //Animator.SetTrigger("jump");
            //Animator.SetBool("isGrounded", false);
            Animator.SetBool("isGrounded", false);
        }

        //move the player along transform forward
        _velocity = transform.TransformDirection(_velocity);
        _controller.Move(_velocity * Time.deltaTime);
    }
}
