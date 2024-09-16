using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    /* NOTE:
     *      Set material surface type to Transparent
     */

    [SerializeField] Vector3[] locationPoints;
    [SerializeField] float timeTaken; // recommended minimum timeTaken should be distance/2
    [SerializeField] float fullyVisibleTime = 2;
    [SerializeField] float timeDelayBeforeNextMove = 2;
    [SerializeField] bool canMove = false;

    bool toReset = false;
    Quaternion originalRotation;

    float timer = 0;
    float interpolateRatio = 0;
    int direction = 1;

    // for switching color alpha
    Renderer _renderer;
    Color opaque;
    Color transparent;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;

        _renderer = GetComponent<Renderer>();
        opaque = _renderer.material.color;
        transparent = new Color(opaque.r, opaque.g, opaque.b, 0);

        transform.position = locationPoints[0];
        _renderer.material.color = transparent;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (timer < timeTaken)
                AppearXDisappear();
            else if (timer > timeTaken + timeDelayBeforeNextMove)
                SetNextMove();

            timer += Time.deltaTime;
        }
        else
        {
            if (toReset)
            {
                ResetGameObject();
                toReset = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.K)) // for debugging only
        {
            AllowedToMove(true);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            AllowedToMove(false);
        }
    }

    public void AllowedToMove(bool trueOrFalse) // call this in manager script
    {
        canMove = trueOrFalse;
        toReset = true;
    }

    void AppearXDisappear()
    {
        interpolateRatio += Time.deltaTime / timeTaken;

        // moving to original or next point
        transform.position = Vector3.Lerp(locationPoints[direction == 0 ? 1 : 0], locationPoints[direction], interpolateRatio);


        if (timer <= timeTaken/2.5f) // making object visible
            _renderer.material.color = Color.Lerp(transparent, opaque, interpolateRatio * 2);
        else if (timer >= timeTaken - timeTaken/2.5f) // making object invisible
            _renderer.material.color = Color.Lerp(opaque, transparent, (interpolateRatio - 0.5f) * 2);
    }

    void SetNextMove()
    {
        // set values to move to the orignal or next point
        transform.Rotate(new Vector3(0, 1, 0), 180);
        direction = direction == 0 ? 1 : 0;
        interpolateRatio = 0;
        timer = 0;
    }

    void ResetGameObject()
    {
        transform.SetPositionAndRotation(locationPoints[0], originalRotation);
        _renderer.material.color = transparent;
        direction = 1;
        interpolateRatio = 0;
        timer = 0;
    }
}
