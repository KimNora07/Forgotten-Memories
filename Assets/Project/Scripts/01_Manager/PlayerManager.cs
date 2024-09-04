using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region MultiSpreading Singleton
    private static PlayerManager _instance;
    private static readonly object _lock = new object();

    public static PlayerManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PlayerManager>();

                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(PlayerManager).Name);
                        _instance = singletonObject.AddComponent<PlayerManager>();
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return _instance;
            }
        }
    }

    protected PlayerManager() { }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
    #endregion

    #region Variable
    public bool canOpen = false;
    #endregion
}
