using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    static public BossStateManager BossStateManagerSingleton;

    // Start is called before the first frame update
    void Start()
    {
        if (BossStateManagerSingleton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            BossStateManagerSingleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
