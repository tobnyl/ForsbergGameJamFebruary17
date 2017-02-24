using UnityEngine;
using System.Collections;

public class AutoDestroyItem : MonoBehaviour
{
    #region Public Fields

    #endregion
    #region Private Fields	

    #endregion
    #region Events

    void Start()
    {
        Invoke("AutoDestroy", GameManager.Instance.DestroyItemAfterTime);
    }

    void Update()
    {

    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }

    #endregion
}
