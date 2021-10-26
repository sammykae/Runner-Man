
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speedIncreasePerPoint = 0.1f;
    public bool alive = true;
    public bool isRunning = false;
    private const float TURN_SPEED = 0.05f;
    private const float LANE_DISTANCE = 3.0f;
    public float speed = 10;
    private float speedIncreaseTick;
    private float speedIncreaseTime = 2.5f;
    private float speedIncreaseAmount = 0.1f;
    private float verticalVelocity;
    private int desiredLane = 1;
    public AudioClip crashSound;
    private AudioSource sound;
    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (!alive) return;
        if (!isRunning) return;
            if (Time.time - speedIncreaseTick > speedIncreaseTime)
        {

            speedIncreaseTick = Time.time;
            if (speed <= 25)
            {
                speed += speedIncreaseAmount;
            }
            
           
        }

        if (MobileInput.Instance.SwipeLeft)
        {
            MoveLane(false);
        }
        if (MobileInput.Instance.SwipeRight)
        {
            MoveLane(true);
        }

        //calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * LANE_DISTANCE;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }


        //calculate move delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        //move the player
        controller.Move(moveVector * Time.deltaTime);

        //rotate to new position
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        }

    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }
    public void Die()
    {
        alive = false;
        anim.SetTrigger("Death");
        sound.PlayOneShot(crashSound, 1f);
        Invoke("Restart", 3);
    }
    public void StartRunning()
    {
        isRunning = true;
        anim.SetTrigger("Running");
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
