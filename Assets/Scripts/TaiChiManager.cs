using UnityEngine;
using UnityEngine.Events;

public class TaiChiManager : MonoBehaviour
{
    #region Singleton Stuff
    public static TaiChiManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    public UnityEvent taichiFinished;
    public UnityEvent resumeTaichi;
}
