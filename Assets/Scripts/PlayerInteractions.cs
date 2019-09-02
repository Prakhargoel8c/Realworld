using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    public GameConstants.Players player;
    private GameManager gameManager;
    public Color color;
    private Movement movement;
    private float interactionDistance;
    private Collider2D[] colliderarray;
    private GameObject currentObject;
    private TextMesh vegetablesText;
    private TextMesh combinationText;
    private string[] vegetablenames;
    private GameObject chopindicator;
    public GameObject UIObject;
    [HideInInspector] public UI GetUI;
    [HideInInspector]public string combination
    {
        get
        {
            if(combinationText.text=="---")
            {
                return null;
            }
            return combinationText.text;
        }
        set
        {
            if (value == null)
            {
                combinationText.text = "---";
            }
            else
            {
                combinationText.text = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        interactionDistance = GameConstants.activationdistance;
        chopindicator = transform.Find("Chopping Indicator").gameObject;
        movement = GetComponent<Movement>();
        vegetablenames = new string[2];
        vegetablesText = transform.Find("Vegetables").GetComponent<TextMesh>();
        combinationText = transform.Find("Chopped Vegetables").GetComponent<TextMesh>();
        currentObject = null;
        GetUI = UIObject.GetComponent<UI>();
        GetUI.SetUi(this);
        GetUI.SetTime(GameConstants.IntialTime);
        gameManager = GameObject.Find("GameManger").GetComponent<GameManager>();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
    public void OnInteract()
    {
        if(currentObject!=null)
        {
            if(currentObject.tag=="Vegetable"&&combination==null)
            {
                string name = currentObject.GetComponent<VegetableName>().Vegetable;
                AddVegetable(name);
                Debug.Log(name);
            }
            else if(currentObject.tag=="ChoppingBoard")
            {
                currentObject.GetComponent<ChoppingBoard>().OnInteract(gameObject);
            }
            else if(currentObject.tag=="Plate" && combination==null)
            {
                currentObject.GetComponent<Plate>().OnInteract(gameObject);
            }
            else if(currentObject.tag== "Dustbin")
            {
                currentObject.GetComponent<Dustbin>().OnInteract(gameObject);
            }
            else if(currentObject.tag== "Customer"&& combination!=null)
            {
                currentObject.GetComponent<Customer>().OnInteract(gameObject);
            }
            else if(currentObject.tag== "ScorePickup")
            {
                currentObject.GetComponent<ScorePowerUp>().OnInteract(gameObject);
            }
            else if(currentObject.tag== "TimePowerUp")
            {
                currentObject.GetComponent<TimePoweUp>().OnInteract(gameObject);
            }
            else if(currentObject.tag== "SpeedPickUp")
            {
                currentObject.GetComponent<SpeedPickUp>().OnInteract(gameObject);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        LayerMask mask = LayerMask.GetMask("Interactable");
        colliderarray = Physics2D.OverlapCircleAll(transform.position, interactionDistance,mask);
        if (colliderarray.Length > 0)
        {
            if (currentObject != colliderarray[0])
            {
                if (currentObject != null)
                {
                    currentObject.GetComponent<Outline>().effectDistance = Vector2.zero;
                }
                currentObject = colliderarray[0].gameObject;
                currentObject.GetComponent<Outline>().effectColor = color;
                currentObject.GetComponent<Outline>().effectDistance = new Vector2(7, 7);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(currentObject!=null)
        {
            currentObject.GetComponent<Outline>().effectDistance = Vector2.zero;
        }
    }
    public string GetVegetable(int index)
    {
        if(vegetablenames[index]==null)
        {
            return null;
        }
        else
        {
            return vegetablenames[index];
        }
    }
    public bool AddVegetable(string vname)
    {
        if (vegetablenames[0] == null)
        {
            vegetablenames[0] = vname;
            vegetablesText.text = vegetablenames[0];
            return true;
        }
        else if (vegetablenames[1] == null)
        {
            vegetablenames[1] = vname;
            vegetablesText.text = vegetablenames[0] + "," + vegetablenames[1];
            return true;
        }
        else
        {
            return false;
        }
    }
    public string RemoveVegetable()
    {
        if(vegetablenames[0]==null)
        {
            return null;
        }
        else
        {
            string temp = vegetablenames[0];
            vegetablenames[0] = vegetablenames[1];
            vegetablenames[1] = null;
            if(vegetablenames[0]==null)
            {
                vegetablesText.text = "---";
            }
            else
            {
                vegetablesText.text = vegetablenames[0];
            }
            return temp;
        }
    }
    public void StartCooking()
    {
        StartCoroutine(Wait());
    }
    public void StopPlayer()
    {
        movement.canMove = false;
        gameManager.SetPlayerFinished(this);

    }
    IEnumerator Wait()
    {
        movement.canMove = false;
        chopindicator.SetActive(true);
        yield return new WaitForSeconds(GameConstants.choptime);
        movement.canMove = true;
        chopindicator.SetActive(false);
    }
    public void IncreaseSpeed()
    {
        StartCoroutine(Speed());
    }
    IEnumerator Speed()
    {
        movement.speed = GameConstants.IncreasedSpeed;
        yield return new WaitForSeconds(GameConstants.SpeedPickUpTime);
        movement.speed = GameConstants.MovementOffset;
    }
}
