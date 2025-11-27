using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Transform PlayerTargert;
    public Transform mirror;

    private void Update()
    {
        Vector3 localPLayer = mirror.InverseTransformPoint(PlayerTargert.position);
        transform.position = PlayerTargert.TransformPoint(new Vector3(localPLayer.x, localPLayer.y, -localPLayer.z));

        Vector3 lookatmirror = mirror.TransformPoint(new Vector3(-localPLayer.x, localPLayer.y, localPLayer.z));
        transform.LookAt(lookatmirror);
    }
}
