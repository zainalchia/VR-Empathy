using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransparency : MonoBehaviour
{
    [SerializeField] private List<GameObject> models;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float cam_angle = Camera.main.transform.eulerAngles.x;
        Debug.Log("Camangle: " + cam_angle);

        foreach (var model in models)
        {
            var temp = model.GetComponent<SkinnedMeshRenderer>().material;
            if (cam_angle > 0 && cam_angle < 100)
                temp.color = new Color(temp.color.r, temp.color.g, temp.color.b, 1 - cam_angle / 90);
            else
                temp.color = new Color(temp.color.r, temp.color.g, temp.color.b, 1);
        }
    }
}
