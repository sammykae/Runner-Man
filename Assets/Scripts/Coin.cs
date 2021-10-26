
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator anim;
    [SerializeField] float turnspeed = 90f;
    public AudioClip coinSound;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnspeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }
        
        GameManager.inst.IncrementScore();
        anim.SetTrigger("Collected");
        sound.PlayOneShot(coinSound,1f);
        Destroy(gameObject,1f);
    }
}
