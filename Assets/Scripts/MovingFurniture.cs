using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFurniture : MonoBehaviour
{
    [SerializeField] float maxDistance = 1f;
    Vector3 originalPos;

    bool isLookedAt = false;
    float timer = 0;
    float nextTimeToMove = 0;
    float minTimeBeforeNextMove = 0.05f;
    float maxTimeBeforeNextMove = 0.5f;

    void FurnitureMove()
    {
        timer += Time.deltaTime;
        if (timer >= nextTimeToMove) 
        {
            MoveRandomiser();
            timer = 0;
            nextTimeToMove = Random.Range(minTimeBeforeNextMove, maxTimeBeforeNextMove); // change timing here
        }
    }

    void MoveRandomiser()
    {
        int rng = Random.Range(0, 6);
        switch (rng) 
        {
            case 0: // move right
                if (transform.position.x + maxDistance > originalPos.x + maxDistance)
                    transform.position = new Vector3(transform.position.x - maxDistance, transform.position.y, transform.position.z);
                else
                    transform.position = new Vector3(transform.position.x + maxDistance, transform.position.y, transform.position.z);
                break;

            case 1: // move up
                if (transform.position.y + maxDistance > originalPos.y + maxDistance)
                    transform.position = new Vector3(transform.position.x, transform.position.y - maxDistance, transform.position.z);
                else
                    transform.position = new Vector3(transform.position.x, transform.position.y + maxDistance, transform.position.z);
                break;

            case 2: // move forward
                if (transform.position.z + maxDistance > originalPos.z + maxDistance)
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - maxDistance);
                else
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + maxDistance);
                break;

            case 3: // move left
                if (transform.position.x - maxDistance < originalPos.x - maxDistance)
                    transform.position = new Vector3(transform.position.x + maxDistance, transform.position.y, transform.position.z);
                else
                    transform.position = new Vector3(transform.position.x - maxDistance, transform.position.y, transform.position.z);
                break;

            case 4: // move down
                if (transform.position.y - maxDistance < originalPos.y) // cannot move below ground
                    transform.position = new Vector3(transform.position.x, transform.position.y + maxDistance, transform.position.z);
                else
                    transform.position = new Vector3(transform.position.x, transform.position.y - maxDistance, transform.position.z);
                break;

            case 5: // move back
                if (transform.position.z - maxDistance < originalPos.z - maxDistance)
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + maxDistance);
                else
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - maxDistance);
                break;
        }
    }

    public void SetIsLookedAt(bool trueOrFalse) // called in InViewDetector script
    {
        isLookedAt = trueOrFalse;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        nextTimeToMove = Random.Range(minTimeBeforeNextMove, maxTimeBeforeNextMove);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLookedAt)
            FurnitureMove();
        else
            transform.position = originalPos;
    }
}
