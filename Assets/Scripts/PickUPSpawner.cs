using UnityEngine;

public class PickUPSpawner : MonoBehaviour
{
    private BoxCollider2D Boxcollider;
    public GameObject[] PickUpPrefabs;
    Vector2 colliderPos;
    // Start is called before the first frame update
    void Start()
    {
        Boxcollider = GetComponent<BoxCollider2D>();
        Vector2 position = new Vector2(Boxcollider.transform.position.x, Boxcollider.transform.position.y);
        colliderPos = position + Boxcollider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPickUp(PlayerInteractions playerInteractions)
    {
       float randomPosX = Random.Range(colliderPos.x - Boxcollider.size.x / 2, colliderPos.x + Boxcollider.size.x / 2);
        float randomPosY = Random.Range(colliderPos.y - Boxcollider.size.y / 2, colliderPos.y + Boxcollider.size.y / 2);
        GameObject SpawnItem = PickUpPrefabs[Random.Range(0, PickUpPrefabs.Length)];
        GameObject instantiatedObject = Instantiate(SpawnItem, new Vector3(randomPosX, randomPosY), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        if(instantiatedObject.tag== "ScorePickup")
        {
            ScorePowerUp scorePowerUp = instantiatedObject.GetComponent<ScorePowerUp>();
            scorePowerUp.playerInteractions = playerInteractions;
            scorePowerUp.SetUi();
        }
        else if(instantiatedObject.tag== "TimePowerUp")
        {
            TimePoweUp timePoweUp = instantiatedObject.GetComponent<TimePoweUp>();
            timePoweUp.playerInteractions = playerInteractions;
            timePoweUp.SetUi();
        }
    }
}
