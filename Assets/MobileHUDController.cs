using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class MobileHUDController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();


    public bool isMobile()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            return IsMobile();
        #endif
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {


        if (isMobile())
        {
            this.gameObject.SetActive(true);
        } 
        else
        {
            this.gameObject.SetActive(false);
        }
    }

}
