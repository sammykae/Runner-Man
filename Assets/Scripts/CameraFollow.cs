

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
 
    [SerializeField] Vector3 offset = new Vector3(0, 5.0f, -10.0f);
    // Start is called before the first frame update


    private void Start()
    {
        transform.position = player.position + offset;
    }
    private void LateUpdate()
    {
       
            Vector3 desiredPosition = player.position + offset;
            desiredPosition.x = 0;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
       
    }
}

