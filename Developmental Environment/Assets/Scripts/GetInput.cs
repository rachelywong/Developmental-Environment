using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

// Script will record player input via controller buttons pressed and print out the value of the button press
// You can change up the actions we record (squeeze action vs. touchpad action vs. your pressure sensor actions from your box)
// Currently, the button press input values are printed out to the console
// You may need to go into the controller binding settings to change what actions each of your buttons do
// For mine for example, the squeeze action = pulling the back trigger on the Vive controller

public class GetInput : MonoBehaviour
{
    // Squeeze action by pulling the back trigger on Vive controller
    public SteamVR_Action_Single squeezeAction;

    // Touch pad action on Vive controller
    public SteamVR_Action_Vector2 touchpadAction;

    // Side squeeze action on Vive controller (Grab grip)
    public SteamVR_Action_Boolean sideSqueezeAction;

    // Update is called once per frame
    void Update()
    {
        // Store the value we get from the action
        // Use float triggerValue to store the squeeze action value from any controller
        float triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);

        // If the triggerValue is greater than 0 (back trigger is pulled), print the triggerValue
        if (triggerValue > 0.0f)
        {
            print(triggerValue);
        }

        // Do the same for the touchpad (position of thumb on touchpad is outputted)
        Vector2 touchpadValue = touchpadAction.GetAxis(SteamVR_Input_Sources.Any);

        if (touchpadValue != Vector2.zero)
        {
            print(touchpadValue);
        }

        // Do the same for the side squeeze (True state is outputted if side grip is squeezed)
        bool sideSqueezeValue = sideSqueezeAction.GetState(SteamVR_Input_Sources.Any); // use GetState for booleans

        if (sideSqueezeValue == true)
        {
            print(sideSqueezeValue);
        }
    }
}
