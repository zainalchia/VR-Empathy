using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransparency : MonoBehaviour
{
    [SerializeField] private List<GameObject> models;

    private List<Material[]> mats;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var model in models)
        {
            mats[models.IndexOf(model)] = model.GetComponent<Renderer>().materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float cam_angle = Camera.main.transform.eulerAngles.x;
        Mathf.Clamp(cam_angle, 0, 90);

        foreach (var matset in mats)
        {
            foreach (var mat in matset)
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, (1 - cam_angle / 90));
            }
        }
    }
}
