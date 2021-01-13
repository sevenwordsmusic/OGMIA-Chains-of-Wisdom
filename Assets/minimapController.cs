using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class minimapController : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool MOBILE;

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

    }


    private void OnEnable()
    {
        if (MOBILE)
        {
            if (!isMobile())
            {
                if (SceneManager.GetActiveScene().name == "level_1" || SceneManager.GetActiveScene().name == "level_2")
                {
                    this.gameObject.SetActive(true);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
            }
            else
            {

            }
        }
        else
        {
            if (isMobile())
            {
                if (SceneManager.GetActiveScene().name == "level_1" || SceneManager.GetActiveScene().name == "level_2")
                {
                    this.gameObject.SetActive(true);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
            }
            else
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
