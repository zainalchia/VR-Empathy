using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public bool FacePlayer;
    private void Update()
    {
        if (FacePlayer) LookAtPlayer(Player);
    }
    public void LookAtPlayer(GameObject Player)
    {
        Quaternion rotation = Quaternion.LookRotation(new Vector3(Player.transform.position.x-gameObject.transform.position.x,0, Player.transform.position.z - gameObject.transform.position.z));
        transform.rotation = rotation;
    }

    
}
