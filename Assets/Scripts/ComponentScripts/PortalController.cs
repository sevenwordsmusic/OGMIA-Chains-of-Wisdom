using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrushers.Wrappers
{
    public class PortalController : MonoBehaviour
    {
        enum Destinations { None, HUB, HUBSave, Level1, Level2, Level3 };
        [SerializeField] Destinations specialDestination = Destinations.None;
        [SerializeField] GameController gameController;

        void Start()
        {
            gameController = GameObject.FindGameObjectWithTag("gameController").GetComponent<GameController>();

            GetComponent<ScenePortal>().teleported += teleport;
        }

        public void teleport()
        {
            switch (specialDestination)
            {
                case Destinations.HUB:
                    gameController.goToHUB();
                    break;
                case Destinations.Level1:
                    gameController.goToLevel(1);
                    break;
                case Destinations.Level2:
                    gameController.goToLevel(2);
                    break;
                case Destinations.Level3:
                    gameController.goToLevel(3);
                    break;
                default:
                    gameController.goToHUB();
                    break;
            }
        }
    }
}
