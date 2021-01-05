using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TutorialTrapController : MonoBehaviour
{
    [SerializeField] float damageInterval = 2f;
    float intervalAux = 0;
    [SerializeField] List<TrapSpikesController> traps = new List<TrapSpikesController>();
    [SerializeField] bool commitChanges = false;
    bool trapsEnabled = false;

    [CustomEditor(typeof(TutorialTrapController))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            TutorialTrapController myScript = (TutorialTrapController)target;
            if (GUILayout.Button("Update Traps"))
            {
                myScript.updateTrapsInit();
                myScript.commitChanges = false;
            }
        }
    }

    void updateTraps(Transform t)
    {
        if (t.tag.Equals("trap"))
        {
            traps.Add(t.GetComponent<TrapSpikesController>());
        }
        if (t.childCount > 0)
        {
            foreach (Transform child in t)
            {
                updateTraps(child);
            }
        }
    }

    void updateTrapsInit()
    {
        traps.Clear();
        Transform t = transform;
        updateTraps(t);
    }



}
