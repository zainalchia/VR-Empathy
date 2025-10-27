using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InViewDetector : MonoBehaviour
{
    List<GameObject> objsInView = new List<GameObject>();
    [SerializeField] PlayerTeleport _playerTeleport;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " is in view");

        if (!objsInView.Contains(other.gameObject))
            objsInView.Add(other.gameObject);

        ObjectiveCheck(other.gameObject,true);
        FurnitureMoveCheck(other.gameObject, true);
        LookAtTeleport(other.gameObject,true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (objsInView.Contains(other.gameObject))
            objsInView.Remove(other.gameObject);

        FurnitureMoveCheck(other.gameObject, false);
        ObjectiveCheck(other.gameObject, false);
        LookAtTeleport(other.gameObject, false);

    }

    void FurnitureMoveCheck(GameObject obj, bool lookingAt)
    {
        if (obj.GetComponent<MovingFurniture>() != null)
        {
            obj.GetComponent<MovingFurniture>().SetIsLookedAt(lookingAt);
        }
    }

    public void ObjectiveCheck(GameObject obj, bool lookingAt)
    {
        if (obj.CompareTag("LookAtInteract"))
        {
            obj.GetComponent<LookAtObjective>().beingLookedAtTrigger(lookingAt);
        }
    }

    public void LookAtTeleport(GameObject obj,bool lookingAt)
    {
        if (obj.CompareTag("TeleportHotspot"))
        {
            _playerTeleport.CheckTeleport(lookingAt);
            obj.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("hover", lookingAt);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
