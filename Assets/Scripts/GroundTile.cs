using System.Collections;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
   
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;
   
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
 
    }

    void OnTriggerExit(Collider other)
    { 
        groundSpawner.SpawnTile(true);
        
        Destroy(gameObject,2f);
    }
   
  
    public void SpawnObstacle()
    {
        //Choose a random point to spawn obstalce
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        //Spawn the obstacle at the point
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

   
    public void SpawnCoin()
    {
        int coinsToSpawn = 2;
        for (int i = 0; i < coinsToSpawn; i++)
        {
         GameObject temp = Instantiate(coinPrefab,transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(((collider.bounds.min.x)+1.5f), ((collider.bounds.max.x)-1.5f)),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }
}
