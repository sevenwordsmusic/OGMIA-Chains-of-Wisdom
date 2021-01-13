using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.UI;

public class multiGraphicButton : Button
{
    protected Button[] buttons;

    protected override void Awake()
    {
        base.Awake();
        buttons = GetComponentsInChildren<Button>();
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        //AUDIO
        if (state.ToString().Equals("Pressed"))
        {
            Debug.Log(FMODUnity.RuntimeManager.CreateInstance("event:/SFX/interface/" + state).start());
        }

        //



        Color color;
        switch (state)
        {
            case SelectionState.Normal:
                foreach(Button button in buttons)
                {
                    button.targetGraphic.color = button.colors.normalColor;
                }
                break;
            case SelectionState.Highlighted:
                foreach (Button button in buttons)
                {
                    button.targetGraphic.color = button.colors.highlightedColor;
                }
                break;
            case SelectionState.Pressed:
                foreach (Button button in buttons)
                {
                    button.targetGraphic.color = button.colors.pressedColor;
                }
                break;
            case SelectionState.Disabled:
                foreach (Button button in buttons)
                {
                    button.targetGraphic.color = button.colors.disabledColor;
                }
                break;
            case SelectionState.Selected:
                foreach (Button button in buttons)
                {
                    button.targetGraphic.color = button.colors.selectedColor;
                }
                break;
            default:
                color = Color.black;
                break;
        }

        base.DoStateTransition(state, instant);
    }

}
