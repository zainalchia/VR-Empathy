using UnityEngine;

public class MovingFurniture : MonoBehaviour
{
    bool isLookedAt = false;

    Vector3 originalScale;

    public bool toDissappear = false;

    [SerializeField]
    float minScale, maxScale;

    [SerializeField]
    Vector3 ScaleChange;

    void RandomScaling()
    {
        transform.localScale += ScaleChange;
        if (transform.localScale.x < 0 || transform.localScale.x > originalScale.x + maxScale)
        {
            ScaleChange = -ScaleChange;
        }
    }

    public void SetIsLookedAt(bool trueOrFalse) // called in InViewDetector script
    {
        isLookedAt = trueOrFalse;

        if (trueOrFalse && !toDissappear && GameManager.instance.toStartSpasming) // first time look at furniture
        {
            toDissappear = true;
        }
    }

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (toDissappear)
        {
            transform.localScale += new Vector3(-1, -1, -1);
            if (transform.localScale.x <= 0)
            {
                this.gameObject.SetActive(false);
                transform.localScale = originalScale;
                toDissappear = false;
            }
        }
        else if (!isLookedAt && GameManager.instance.toStartSpasming)
            RandomScaling();

        if (!GameManager.instance.toStartSpasming)
        {
            transform.localScale = originalScale;
        }
    }
}
