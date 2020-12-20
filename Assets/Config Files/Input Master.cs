// GENERATED AUTOMATICALLY FROM 'Assets/ConfigFiles/Input Master 1.inputactions'

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
                    ""type"": ""PassThrough"",
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
                    ""name"": ""CameraSnapLeft"",
                    ""type"": ""Button"",
                    ""id"": ""00a87ed7-8080-4bc9-8a1c-13a8a8860d8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""CameraSnapRight"",
                    ""type"": ""Button"",
                    ""id"": ""4cb43f09-1274-45da-8863-2652c4abe6eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
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
                    ""name"": ""Concentration"",
                    ""type"": ""Button"",
                    ""id"": ""f589a21c-2ab3-496c-b433-1bd829f55362"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""d756bb49-7c4d-41a3-b58d-67d582830dfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a6d6121a-b62f-4378-b502-76937b88614d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64f16834-22c6-4111-b27c-ca6c936810fc"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
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
                    ""name"": """",
                    ""id"": ""94854ab5-8895-4cb7-bbe2-6070b95a5bac"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d79d60b-cc01-4a35-9597-12bd1a8b2caa"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""CameraSnapLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""026454b7-e72b-46da-aee5-4dfe9d79e666"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CameraSnapLeft"",
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
                    ""groups"": ""Controller"",
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
                    ""id"": ""50b7aff6-0bfb-4522-83f3-8cf8cf783048"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""CameraSnapRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2d84ac0-4c36-4a7d-81c4-ad01f3da137b"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CameraSnapRight"",
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
                    ""groups"": ""Controller"",
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
                    ""groups"": ""Controller"",
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
                    ""id"": ""38169f37-bc28-48c1-99fa-8003ae33e6eb"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Concentration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35b43d39-5cf1-413c-9d52-3a6fae950ba5"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Concentration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34f8d87f-254f-4d58-9b36-21b93ff34796"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54a2b026-eac7-4a79-b88e-23a34fbc75ed"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat_Menu"",
            ""id"": ""513d6961-1a3c-4a10-8756-f674761a0abe"",
            ""actions"": [
                {
                    ""name"": ""Concentration"",
                    ""type"": ""Button"",
                    ""id"": ""c7661c71-555b-4262-ac8e-5970bcfb5067"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""631be15a-de55-40e3-a971-4d32e3f55bb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8dc9cc6b-c90d-42e0-9586-99aaff75e0b5"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Concentration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbfe2ad8-0437-4a6c-ad16-1fe36bb1b96d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Concentration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d02894de-4948-444f-972c-5ea63df3040a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d21873b-eeb9-490c-9494-cb45e3a415a7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Enemy_Selection"",
            ""id"": ""ab0be66a-93b0-45d1-a272-8341c7032bd3"",
            ""actions"": [
                {
                    ""name"": ""ChangeSelectedEnemy"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4cadbabd-f4e2-4734-8cd8-b180ffa9e82e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelEnemySelection"",
                    ""type"": ""Button"",
                    ""id"": ""68ed6980-5b26-48a7-bc50-3c6d775a64fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectEnemy"",
                    ""type"": ""Button"",
                    ""id"": ""17e11887-80e5-412e-8086-71b2a43a6f8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ffc50ca-6867-4c3e-944e-983d1a412f26"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ChangeSelectedEnemy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4b526bb-bab3-436a-a0ad-823417ca0fe5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ChangeSelectedEnemy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97565acb-4337-43ca-bd27-f313fb26a25a"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""ChangeSelectedEnemy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""652c9682-20ad-49cc-896a-1b14c5050947"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CancelEnemySelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4e407b1-3c66-4a08-b62f-ee37a6511e2e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""CancelEnemySelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b1257e5-98e8-4f9c-9240-1480e0095dcc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SelectEnemy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e72b809-5b04-46b6-94bd-96cb762e7ceb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""SelectEnemy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba14ee72-7842-4c21-925f-938d4cb746bf"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""SelectEnemy"",
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
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_CameraSnapLeft = m_Player.FindAction("CameraSnapLeft", throwIfNotFound: true);
        m_Player_CameraSnapRight = m_Player.FindAction("CameraSnapRight", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_MouseAim = m_Player.FindAction("MouseAim", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Block = m_Player.FindAction("Block", throwIfNotFound: true);
        m_Player_LockOn = m_Player.FindAction("LockOn", throwIfNotFound: true);
        m_Player_ChangeLockOn = m_Player.FindAction("ChangeLockOn", throwIfNotFound: true);
        m_Player_Concentration = m_Player.FindAction("Concentration", throwIfNotFound: true);
        m_Player_Respawn = m_Player.FindAction("Respawn", throwIfNotFound: true);
        // Combat_Menu
        m_Combat_Menu = asset.FindActionMap("Combat_Menu", throwIfNotFound: true);
        m_Combat_Menu_Concentration = m_Combat_Menu.FindAction("Concentration", throwIfNotFound: true);
        m_Combat_Menu_Cancel = m_Combat_Menu.FindAction("Cancel", throwIfNotFound: true);
        // Enemy_Selection
        m_Enemy_Selection = asset.FindActionMap("Enemy_Selection", throwIfNotFound: true);
        m_Enemy_Selection_ChangeSelectedEnemy = m_Enemy_Selection.FindAction("ChangeSelectedEnemy", throwIfNotFound: true);
        m_Enemy_Selection_CancelEnemySelection = m_Enemy_Selection.FindAction("CancelEnemySelection", throwIfNotFound: true);
        m_Enemy_Selection_SelectEnemy = m_Enemy_Selection.FindAction("SelectEnemy", throwIfNotFound: true);
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
    private readonly InputAction m_Player_CameraSnapLeft;
    private readonly InputAction m_Player_CameraSnapRight;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_MouseAim;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Block;
    private readonly InputAction m_Player_LockOn;
    private readonly InputAction m_Player_ChangeLockOn;
    private readonly InputAction m_Player_Concentration;
    private readonly InputAction m_Player_Respawn;
    public struct PlayerActions
    {
        private @InputMaster1 m_Wrapper;
        public PlayerActions(@InputMaster1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @CameraSnapLeft => m_Wrapper.m_Player_CameraSnapLeft;
        public InputAction @CameraSnapRight => m_Wrapper.m_Player_CameraSnapRight;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @MouseAim => m_Wrapper.m_Player_MouseAim;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Block => m_Wrapper.m_Player_Block;
        public InputAction @LockOn => m_Wrapper.m_Player_LockOn;
        public InputAction @ChangeLockOn => m_Wrapper.m_Player_ChangeLockOn;
        public InputAction @Concentration => m_Wrapper.m_Player_Concentration;
        public InputAction @Respawn => m_Wrapper.m_Player_Respawn;
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
                @CameraSnapLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSnapLeft;
                @CameraSnapLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSnapLeft;
                @CameraSnapLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSnapLeft;
                @CameraSnapRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSnapRight;
                @CameraSnapRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSnapRight;
                @CameraSnapRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSnapRight;
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
                @Concentration.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnConcentration;
                @Concentration.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnConcentration;
                @Concentration.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnConcentration;
                @Respawn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRespawn;
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
                @CameraSnapLeft.started += instance.OnCameraSnapLeft;
                @CameraSnapLeft.performed += instance.OnCameraSnapLeft;
                @CameraSnapLeft.canceled += instance.OnCameraSnapLeft;
                @CameraSnapRight.started += instance.OnCameraSnapRight;
                @CameraSnapRight.performed += instance.OnCameraSnapRight;
                @CameraSnapRight.canceled += instance.OnCameraSnapRight;
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
                @Concentration.started += instance.OnConcentration;
                @Concentration.performed += instance.OnConcentration;
                @Concentration.canceled += instance.OnConcentration;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Combat_Menu
    private readonly InputActionMap m_Combat_Menu;
    private ICombat_MenuActions m_Combat_MenuActionsCallbackInterface;
    private readonly InputAction m_Combat_Menu_Concentration;
    private readonly InputAction m_Combat_Menu_Cancel;
    public struct Combat_MenuActions
    {
        private @InputMaster1 m_Wrapper;
        public Combat_MenuActions(@InputMaster1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Concentration => m_Wrapper.m_Combat_Menu_Concentration;
        public InputAction @Cancel => m_Wrapper.m_Combat_Menu_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_Combat_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Combat_MenuActions set) { return set.Get(); }
        public void SetCallbacks(ICombat_MenuActions instance)
        {
            if (m_Wrapper.m_Combat_MenuActionsCallbackInterface != null)
            {
                @Concentration.started -= m_Wrapper.m_Combat_MenuActionsCallbackInterface.OnConcentration;
                @Concentration.performed -= m_Wrapper.m_Combat_MenuActionsCallbackInterface.OnConcentration;
                @Concentration.canceled -= m_Wrapper.m_Combat_MenuActionsCallbackInterface.OnConcentration;
                @Cancel.started -= m_Wrapper.m_Combat_MenuActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_Combat_MenuActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_Combat_MenuActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_Combat_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Concentration.started += instance.OnConcentration;
                @Concentration.performed += instance.OnConcentration;
                @Concentration.canceled += instance.OnConcentration;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public Combat_MenuActions @Combat_Menu => new Combat_MenuActions(this);

    // Enemy_Selection
    private readonly InputActionMap m_Enemy_Selection;
    private IEnemy_SelectionActions m_Enemy_SelectionActionsCallbackInterface;
    private readonly InputAction m_Enemy_Selection_ChangeSelectedEnemy;
    private readonly InputAction m_Enemy_Selection_CancelEnemySelection;
    private readonly InputAction m_Enemy_Selection_SelectEnemy;
    public struct Enemy_SelectionActions
    {
        private @InputMaster1 m_Wrapper;
        public Enemy_SelectionActions(@InputMaster1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChangeSelectedEnemy => m_Wrapper.m_Enemy_Selection_ChangeSelectedEnemy;
        public InputAction @CancelEnemySelection => m_Wrapper.m_Enemy_Selection_CancelEnemySelection;
        public InputAction @SelectEnemy => m_Wrapper.m_Enemy_Selection_SelectEnemy;
        public InputActionMap Get() { return m_Wrapper.m_Enemy_Selection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Enemy_SelectionActions set) { return set.Get(); }
        public void SetCallbacks(IEnemy_SelectionActions instance)
        {
            if (m_Wrapper.m_Enemy_SelectionActionsCallbackInterface != null)
            {
                @ChangeSelectedEnemy.started -= m_Wrapper.m_Enemy_SelectionActionsCallbackInterface.OnChangeSelectedEnemy;
                @ChangeSelectedEnemy.performed -= m_Wrapper.m_Enemy_SelectionActionsCallbackInterface.OnChangeSelectedEnemy;
                @ChangeSelectedEnemy.canceled -= m_Wrapper.m_Enemy_SelectionActionsCallbackInterface.OnChangeSelectedEnemy;
                @CancelEnemySelection.started -= m_Wrapper.m_Enemy_SelectionActionsCallbackInterface.OnCancelEnemySelection;
                @CancelEnemySelection.performed -= m_Wrapper.m_Enemy_SelectionActionsCallbackInterface.OnCancelEnemySelection;
                @CancelEnemySelection.canceled -= m_Wrapper.m_Enemy_SelectionActionsCallbackInterface.OnCancelEnemySelection;
                @SelectEnemy.started -= m_Wrapper.m_Enemy_SelectionActionsCallbackInterface.OnSelectEnemy;
                @SelectEnemy.performed -= m_Wrapper.m_Enemy_SelectionActionsCallbackInterface.OnSelectEnemy;
                @SelectEnemy.canceled -= m_Wrapper.m_Enemy_SelectionActionsCallbackInterface.OnSelectEnemy;
            }
            m_Wrapper.m_Enemy_SelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ChangeSelectedEnemy.started += instance.OnChangeSelectedEnemy;
                @ChangeSelectedEnemy.performed += instance.OnChangeSelectedEnemy;
                @ChangeSelectedEnemy.canceled += instance.OnChangeSelectedEnemy;
                @CancelEnemySelection.started += instance.OnCancelEnemySelection;
                @CancelEnemySelection.performed += instance.OnCancelEnemySelection;
                @CancelEnemySelection.canceled += instance.OnCancelEnemySelection;
                @SelectEnemy.started += instance.OnSelectEnemy;
                @SelectEnemy.performed += instance.OnSelectEnemy;
                @SelectEnemy.canceled += instance.OnSelectEnemy;
            }
        }
    }
    public Enemy_SelectionActions @Enemy_Selection => new Enemy_SelectionActions(this);
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
    public interface IPlayerActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCameraSnapLeft(InputAction.CallbackContext context);
        void OnCameraSnapRight(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMouseAim(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnChangeLockOn(InputAction.CallbackContext context);
        void OnConcentration(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
    }
    public interface ICombat_MenuActions
    {
        void OnConcentration(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
    public interface IEnemy_SelectionActions
    {
        void OnChangeSelectedEnemy(InputAction.CallbackContext context);
        void OnCancelEnemySelection(InputAction.CallbackContext context);
        void OnSelectEnemy(InputAction.CallbackContext context);
    }
}
