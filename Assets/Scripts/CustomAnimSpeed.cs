using UnityEngine;

public class CustomAnimSpeed : MonoBehaviour
{
    [Range(0f, 1f)]
    public float speed = 1f;

    void Start()
    {
        GetComponent<Animator>().speed = speed;
    }
}
