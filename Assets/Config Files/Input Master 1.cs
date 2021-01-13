// GENERATED AUTOMATICALLY FROM 'Assets/Config Files/Input Master 1.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster1 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster1()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input Master 1"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""06a538a2-ef19-45e3-b322-956811740e06"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""350b9a0a-1310-4805-b838-25e02efe1c4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c4df0fe5-a556-4fd0-a272-972d3ae9c0f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3d0a9c48-7d73-4741-a94c-95555425af6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""0bc86047-b3e4-4017-8106-774007592aa2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""MouseAim"",
                    ""type"": ""Value"",
                    ""id"": ""a429fc9e-03ca-49e6-a355-7574b1bdab2a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""ff18b633-ce67-4f25-9d0f-a2aa86b3a69b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""2d021332-1228-416e-9b94-fad2805cf03f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""1c695add-9e65-4075-ae01-a9441d9125e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeLockOn"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7d701f5a-344a-402f-931f-e68ce48dc8ff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""360Attack"",
                    ""type"": ""Button"",
                    ""id"": ""12745917-e305-4973-b6d1-552910af697c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraControl"",
                    ""type"": ""Value"",
                    ""id"": ""2344baa1-f4d4-475c-8bad-0a977d098d54"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b4aa83b2-2b26-4103-9776-ec1c194ec017"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Value"",
                    ""id"": ""c2755513-13e6-4e5f-9be5-10254eb79aeb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnableCameraRotation"",
                    ""type"": ""Button"",
                    ""id"": ""cdb15f7c-003c-47ae-8104-c851f752061d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""enableCheats1"",
                    ""type"": ""Button"",
                    ""id"": ""24d95099-a187-4c46-990d-2dd59581c3f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""enableCheats2"",
                    ""type"": ""Button"",
                    ""id"": ""48437af9-e229-4ca8-9c36-0fb9848e9d81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CheatGainCrystal"",
                    ""type"": ""Button"",
                    ""id"": ""28b89ffc-fbc1-40c2-ba9a-48eb82134fa7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CheatReturnToMD"",
                    ""type"": ""Button"",
                    ""id"": ""b6505e7c-4ae6-4544-ada8-874f9c5a3926"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""64f16834-22c6-4111-b27c-ca6c936810fc"",
                    ""path"": ""<AndroidGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""687fcf7a-585e-4c1c-b596-90b096f4ce21"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e33aed25-3f81-4ab7-b911-7282b48b458b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28025995-b55b-4960-8fb8-f97a48211521"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""88006685-ef57-4834-a262-1be33d7fb477"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4c68bedc-fbf5-4ec4-9b38-451e743e70bb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eeb6f31b-e071-4978-b62b-a0c0866adea9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8812a3b4-d940-4772-92ac-b49a9017108e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aa6b0cb3-6008-47bc-aa3c-a1c10faef827"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow keys"",
                    ""id"": ""71060207-ec61-4e74-a92c-1cc85da82531"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a8254ae4-d1a5-48af-b13e-613540ae2669"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""481f0fbb-8a9e-4f7c-8f8d-f693da07ea78"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a7324f12-4686-4dd3-864f-cc2010d222b6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e445d49e-411f-4dd6-90cf-3f15de74ae68"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5fafa690-a9bf-41ad-92ce-6192e873d7eb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;Touch"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6021c6f3-b6d8-431c-8430-5370f41c9abd"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c43edbd6-5297-416e-8ef3-00f5e33290eb"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca8b7883-a913-4903-944a-840b631b25b3"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""MouseAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61a370e3-2bf2-4433-bd2a-a47b63b34363"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MouseAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcd43a91-2d1d-46fb-94f9-9b2fef002c16"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a503fa2-499a-4a05-ab42-8d9d5b283920"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7badecb2-0f55-46c5-b6df-4f8d3c356396"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;Touch"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""680944b1-4c16-490a-ad2e-65a0d929891d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62bad15f-527b-4285-800e-b287954af5a3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;Touch"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e13cc43-1184-4785-8210-9f8d1705986b"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72804386-6a25-45ba-b6d3-378ec2c3238b"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0dbc98f-9392-43f6-b2c9-7627839cc0f0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""524352a9-e1ee-4e6b-b445-67e37bbc37db"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""ChangeLockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c55f0b5-5871-4692-b544-01a0c66f640b"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ChangeLockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb45cca6-ca6e-465f-92d2-fc9190db0e98"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""SlowTap(duration=0.3)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""360Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa71da22-7e9c-4ffa-8e2b-af12c04f135d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""360Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f04a717-35ae-45dc-a5da-65d461180258"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""360Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""158a7086-c35a-4517-9bf4-59cc3a7f4570"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;Touch"",
                    ""action"": ""CameraControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""219a71ef-c941-4fad-a0b1-edad4c48a6e8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de310460-0ddf-4b4d-951c-bd7527c9a86a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;Touch"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c8a3302-8874-44b8-b9b8-b349952476b6"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9cb5894-7542-4dbf-9d8e-7b7542191e92"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Controller;Touch"",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37f38dfb-f9d1-4aa1-a375-0570af50e818"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25a159ca-6ad6-40da-a12e-6d4b9e26220b"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""EnableCameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""736efa1a-3a2f-4530-9917-77c363bd6401"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""enableCheats1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b78fc484-2fc1-452d-bd52-dd32668be2a9"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""enableCheats1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6999e7e8-1b74-4081-93ed-6a14293798b4"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""enableCheats2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2ed7014-84bb-4e52-a98e-608965e71e54"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""enableCheats2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b03b658-afe9-4a18-8a53-b10b8d74dfe5"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""CheatGainCrystal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fbc6d43-bb19-43a4-ad36-c1ddc83f3c55"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CheatGainCrystal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2508e93-5d49-4dd7-8c38-8031bf2fda90"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""CheatReturnToMD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7b3fc2c-6c4f-4263-80dd-e22399c2c0b7"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CheatReturnToMD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard + mouse"",
            ""bindingGroup"": ""Keyboard + mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_MouseAim = m_Player.FindAction("MouseAim", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Block = m_Player.FindAction("Block", throwIfNotFound: true);
        m_Player_LockOn = m_Player.FindAction("LockOn", throwIfNotFound: true);
        m_Player_ChangeLockOn = m_Player.FindAction("ChangeLockOn", throwIfNotFound: true);
        m_Player__360Attack = m_Player.FindAction("360Attack", throwIfNotFound: true);
        m_Player_CameraControl = m_Player.FindAction("CameraControl", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_RotateCamera = m_Player.FindAction("RotateCamera", throwIfNotFound: true);
        m_Player_EnableCameraRotation = m_Player.FindAction("EnableCameraRotation", throwIfNotFound: true);
        m_Player_enableCheats1 = m_Player.FindAction("enableCheats1", throwIfNotFound: true);
        m_Player_enableCheats2 = m_Player.FindAction("enableCheats2", throwIfNotFound: true);
        m_Player_CheatGainCrystal = m_Player.FindAction("CheatGainCrystal", throwIfNotFound: true);
        m_Player_CheatReturnToMD = m_Player.FindAction("CheatReturnToMD", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_MouseAim;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Block;
    private readonly InputAction m_Player_LockOn;
    private readonly InputAction m_Player_ChangeLockOn;
    private readonly InputAction m_Player__360Attack;
    private readonly InputAction m_Player_CameraControl;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_RotateCamera;
    private readonly InputAction m_Player_EnableCameraRotation;
    private readonly InputAction m_Player_enableCheats1;
    private readonly InputAction m_Player_enableCheats2;
    private readonly InputAction m_Player_CheatGainCrystal;
    private readonly InputAction m_Player_CheatReturnToMD;
    public struct PlayerActions
    {
        private @InputMaster1 m_Wrapper;
        public PlayerActions(@InputMaster1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @MouseAim => m_Wrapper.m_Player_MouseAim;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Block => m_Wrapper.m_Player_Block;
        public InputAction @LockOn => m_Wrapper.m_Player_LockOn;
        public InputAction @ChangeLockOn => m_Wrapper.m_Player_ChangeLockOn;
        public InputAction @_360Attack => m_Wrapper.m_Player__360Attack;
        public InputAction @CameraControl => m_Wrapper.m_Player_CameraControl;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @RotateCamera => m_Wrapper.m_Player_RotateCamera;
        public InputAction @EnableCameraRotation => m_Wrapper.m_Player_EnableCameraRotation;
        public InputAction @enableCheats1 => m_Wrapper.m_Player_enableCheats1;
        public InputAction @enableCheats2 => m_Wrapper.m_Player_enableCheats2;
        public InputAction @CheatGainCrystal => m_Wrapper.m_Player_CheatGainCrystal;
        public InputAction @CheatReturnToMD => m_Wrapper.m_Player_CheatReturnToMD;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @MouseAim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseAim;
                @MouseAim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseAim;
                @MouseAim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseAim;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Block.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @LockOn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockOn;
                @ChangeLockOn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeLockOn;
                @ChangeLockOn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeLockOn;
                @ChangeLockOn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeLockOn;
                @_360Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_360Attack;
                @_360Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_360Attack;
                @_360Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_360Attack;
                @CameraControl.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraControl;
                @CameraControl.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraControl;
                @CameraControl.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraControl;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @RotateCamera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateCamera;
                @EnableCameraRotation.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEnableCameraRotation;
                @EnableCameraRotation.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEnableCameraRotation;
                @EnableCameraRotation.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEnableCameraRotation;
                @enableCheats1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEnableCheats1;
                @enableCheats1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEnableCheats1;
                @enableCheats1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEnableCheats1;
                @enableCheats2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEnableCheats2;
                @enableCheats2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEnableCheats2;
                @enableCheats2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEnableCheats2;
                @CheatGainCrystal.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCheatGainCrystal;
                @CheatGainCrystal.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCheatGainCrystal;
                @CheatGainCrystal.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCheatGainCrystal;
                @CheatReturnToMD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCheatReturnToMD;
                @CheatReturnToMD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCheatReturnToMD;
                @CheatReturnToMD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCheatReturnToMD;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @MouseAim.started += instance.OnMouseAim;
                @MouseAim.performed += instance.OnMouseAim;
                @MouseAim.canceled += instance.OnMouseAim;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @ChangeLockOn.started += instance.OnChangeLockOn;
                @ChangeLockOn.performed += instance.OnChangeLockOn;
                @ChangeLockOn.canceled += instance.OnChangeLockOn;
                @_360Attack.started += instance.On_360Attack;
                @_360Attack.performed += instance.On_360Attack;
                @_360Attack.canceled += instance.On_360Attack;
                @CameraControl.started += instance.OnCameraControl;
                @CameraControl.performed += instance.OnCameraControl;
                @CameraControl.canceled += instance.OnCameraControl;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
                @EnableCameraRotation.started += instance.OnEnableCameraRotation;
                @EnableCameraRotation.performed += instance.OnEnableCameraRotation;
                @EnableCameraRotation.canceled += instance.OnEnableCameraRotation;
                @enableCheats1.started += instance.OnEnableCheats1;
                @enableCheats1.performed += instance.OnEnableCheats1;
                @enableCheats1.canceled += instance.OnEnableCheats1;
                @enableCheats2.started += instance.OnEnableCheats2;
                @enableCheats2.performed += instance.OnEnableCheats2;
                @enableCheats2.canceled += instance.OnEnableCheats2;
                @CheatGainCrystal.started += instance.OnCheatGainCrystal;
                @CheatGainCrystal.performed += instance.OnCheatGainCrystal;
                @CheatGainCrystal.canceled += instance.OnCheatGainCrystal;
                @CheatReturnToMD.started += instance.OnCheatReturnToMD;
                @CheatReturnToMD.performed += instance.OnCheatReturnToMD;
                @CheatReturnToMD.canceled += instance.OnCheatReturnToMD;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardmouseSchemeIndex = -1;
    public InputControlScheme KeyboardmouseScheme
    {
        get
        {
            if (m_KeyboardmouseSchemeIndex == -1) m_KeyboardmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard + mouse");
            return asset.controlSchemes[m_KeyboardmouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMouseAim(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnChangeLockOn(InputAction.CallbackContext context);
        void On_360Attack(InputAction.CallbackContext context);
        void OnCameraControl(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
        void OnEnableCameraRotation(InputAction.CallbackContext context);
        void OnEnableCheats1(InputAction.CallbackContext context);
        void OnEnableCheats2(InputAction.CallbackContext context);
        void OnCheatGainCrystal(InputAction.CallbackContext context);
        void OnCheatReturnToMD(InputAction.CallbackContext context);
    }
}
