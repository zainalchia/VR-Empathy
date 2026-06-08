using Oculus.Interaction;
using System;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

enum Hand
{
    Left,
    Right,
    Current,
    Free
}

public class SequenceManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text debugText;
    // sequence event class defines
    [Serializable]
    public class SequenceEvent
    {
        public string name;
#if UNITY_EDITOR // this is an editor utility ONLY, for swapping between sequence event types
        public enum SequenceEventEnum
        {
            [InspectorName("None")] SET_None,
            [InspectorName("Show Prompt")] SET_Text,
            [InspectorName("Wait")] SET_WaitSeconds,
            [InspectorName("Wait for item pickup")] SET_WaitForItemPickup,
            [InspectorName("Wait for item drop")] SET_WaitForItemDrop,
            [InspectorName("Play audio")] SET_PlayAudioClip,
            [InspectorName("Set GameObject active")] SET_SetGameObjectActive,
            [InspectorName("Wait for GameObject active")] SET_WaitGameObjectActive,
            [InspectorName("Force user to hold item")] SET_ForceGrab,
            [InspectorName("Force user to drop item")] SET_ForceDrop,
            [InspectorName("Set post-processing weight")] SET_SetPostProcessWeight,
            [InspectorName("Wait for distance between objects")] SET_WaitDistance,
            [InspectorName("Trigger Unity Event")] SET_UnityEvent,
            [InspectorName("Go to scene")] SET_GoToScene,
            [InspectorName("Change material color")] SET_ChangeMaterialColor,
            [InspectorName("Change texture")] SET_ChangeMaterialTexture,
            [InspectorName("Change material")] SET_ChangeMaterial,
            [InspectorName("Wait for trigger")] SET_WaitForTrigger,
            [InspectorName("Wait for target piece")] SET_WaitForTargetPiece,
            [InspectorName("Set position")] SET_SetGOPosition,
            [InspectorName("Instantiate GO")] SET_InstantiateGO,
            [InspectorName("Wait for GameObject destroyed")] SET_WaitGameObjectDestroy,
            [InspectorName("Wait for flag")] SET_WaitForFlag,
            [InspectorName("Go to second scenario")] SET_GoToSecondScenario,
            [InspectorName("Set rotation")] SET_SetRotation,
            [InspectorName("Add to LevelsPlayed list")] SET_AddToLevelsPlayedList,
            [InspectorName("")] SET_COUNT // NOT an actual type! here for easy counting!!!
        }

        public static readonly System.Type[] SequenceEventTypes = new System.Type[(int)SequenceEventEnum.SET_COUNT]
        {
            typeof(SequenceEvent                    ),
            typeof(SEvent_Text                      ),
            typeof(SEvent_WaitSeconds               ),
            typeof(SEvent_WaitForItemPickup         ),
            typeof(SEvent_WaitForItemDrop           ),
            typeof(SEvent_PlayAudio                 ),
            typeof(SEvent_SetGameObjectActive       ),
            typeof(SEvent_WaitForGameObjectActive   ),
            typeof(SEvent_ForceGrab                 ),
            typeof(SEvent_ForceDrop                 ),
            typeof(SEvent_LerpPostProcessingWeight  ),
            typeof(SEvent_WaitForDistance           ),
            typeof(SEvent_TriggerUnityEvent         ),
            typeof(SEvent_GoToScene                 ),
            typeof(SEvent_ChangeMaterialColor       ),
            typeof(SEvent_ChangeMaterialTexture     ),
            typeof(SEvent_ChangeMaterial            ),
            typeof(SEvent_WaitForTrigger            ),
            typeof(SEvent_WaitForTargetPiece        ),
            typeof(SEvent_SetPosition               ),
            typeof(SEvent_InstantiateGO             ),
            typeof(SEvent_WaitGameObjectDestroy     ),
            typeof(SEvent_WaitForFlag               ),
            typeof(SEvent_GoToSecondScenario        ),
            typeof(SEvent_SetRotation               ),
            typeof(SEvent_AddToLevelsPlayedList     ),
        };

        public SequenceEventEnum type;
#endif

        // non-editor properties
        public bool exitFlag { get; private set; }

        // functions
        public void Exit()
        {
            exitFlag = true;
        }
        public void Reset()
        {
            exitFlag = false;
            this.OnReset();
        }


        // virtual event defines
        public virtual void OnReset() { }
        public virtual void OnEnter() { }
        public virtual void Update() { }
        public virtual void OnExit() { }


    }

    [Serializable]
    public class SEvent_Text : SequenceEvent
    {
        [SerializeField] string text;
        [SerializeField] float duration;

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("[SEvent_Text DEBUG] " + text);
            ScenarioPromptManager.instance.ShowPrompt(text, duration);
            Exit();
        }
    }

    [Serializable]
    public class SEvent_WaitSeconds : SequenceEvent
    {
        [SerializeField] float waitTime;
        float timer;
        public override void OnReset()
        {
            timer = 0;
        }

        public override void Update()
        {
            base.Update();
            timer += Time.deltaTime;
            if (timer >= waitTime) Exit();
        }
    }

    [Serializable]
    public class SEvent_WaitForItemPickup : SequenceEvent
    {
        [SerializeField] GrabInteractable interactable;
        [SerializeField] bool outlineItem;
        [SerializeField] bool itemStaysGrabbed;
        [SerializeField] bool forceEnableGrabbable;

        public override void OnEnter()
        {
            base.OnEnter();

            // check if assigned grabbable exists
            if (interactable == null)
            {
                Exit();
                return;
            }

            // force enable pickup components.
            if (forceEnableGrabbable)
            {
                interactable.enabled = true;
                Grabbable grabbable = interactable.GetComponent<Grabbable>();
                if (grabbable != null) grabbable.enabled = true;
                PhysicsGrabbable physicsGrabbable = interactable.GetComponent<PhysicsGrabbable>();
                if (physicsGrabbable != null) physicsGrabbable.enabled = true;
            }

            // outline item, if applicable
            if (outlineItem)
            {
                Outline outline = interactable.gameObject.GetComponent<Outline>();
                if (outline == null) return;
                outline.enabled = true;
            }

        }

        public override void Update()
        {
            base.Update();
            if (ThymeVRUtility.IsHeld(interactable))
                Exit();
        }

        public override void OnExit()
        {
            base.OnExit();

            if (itemStaysGrabbed)
            {
                if (GameManager.instance.grabInteractors[0].SelectedInteractable == interactable)
                    GameManager.instance.grabInteractors[0].ForceSelect(interactable);
                if (GameManager.instance.grabInteractors[1].SelectedInteractable == interactable)
                    GameManager.instance.grabInteractors[1].ForceSelect(interactable);
            }

            // un-outline item, if applicable
            if (outlineItem)
            {
                Outline outline = interactable.gameObject.GetComponent<Outline>();
                if (outline == null) return;
                outline.enabled = false;
            }
        }
    }

    public class SEvent_WaitForItemDrop : SequenceEvent
    {
        [SerializeField] GrabInteractable interactable;

        public override void Update()
        {
            base.Update();
            if (!ThymeVRUtility.IsHeld(interactable))
                Exit();
        }
    }

    public class SEvent_PlayAudio : SequenceEvent
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip audioClip;
        [SerializeField] AudioClip audioClipAlt;
        [SerializeField] bool waitForEnd = true;
        [SerializeField] bool loop = false;

        public override void OnEnter()
        {
            base.OnEnter();
            audioSource.loop = false;
            audioSource.Stop();

            // play alternate voiceline, if applicable
            if (MainMenuManager.isGenderMale && (audioClipAlt != null))
                audioSource.clip = audioClipAlt;

            // play default voiceline
            else
                audioSource.clip = audioClip;

            audioSource.Play();
            audioSource.loop = loop;
        }

        public override void Update()
        {
            base.Update();
            if (waitForEnd && audioSource.isPlaying) return; // ignore if we want to wait for the end AND the audio source is playing
            Exit();
        }

    }

    public class SEvent_SetGameObjectActive : SequenceEvent
    {
        [SerializeField] GameObject gameObject;
        [SerializeField] bool active = true;

        public override void OnEnter()
        {
            base.OnEnter();
            if (gameObject != null) gameObject.SetActive(active);
            Exit();
        }
    }

    public class SEvent_WaitForGameObjectActive : SequenceEvent
    {
        [SerializeField] GameObject[] gameObjects;
        [SerializeField] bool active = true;

        public override void OnEnter()
        {
            base.OnEnter(); 
            foreach (GameObject go in gameObjects)
            {
                if (go == null) Exit();
            }
        }

        public override void Update()
        {
            base.Update();
            foreach(GameObject go in gameObjects)
            {
                if (go.activeInHierarchy != active) return;
            }
            Exit();
        }
    }

    public class SEvent_ForceGrab : SequenceEvent
    {
        [SerializeField] Hand hand;
        [SerializeField] GrabInteractable interactable;

        public override void OnEnter()
        {
            base.OnEnter();
            switch (hand)
            {
                case Hand.Left:
                    {
                        GameManager.instance.grabInteractors[0].ForceSelect(interactable);
                        break;
                    }

                case Hand.Right:
                    {
                        GameManager.instance.grabInteractors[1].ForceSelect(interactable);
                        break;
                    }

                case Hand.Current:
                    if (GameManager.instance.grabInteractors[0].SelectedInteractable == interactable)
                        GameManager.instance.grabInteractors[0].ForceSelect(interactable);
                    if (GameManager.instance.grabInteractors[1].SelectedInteractable == interactable)
                        GameManager.instance.grabInteractors[1].ForceSelect(interactable);
                    break;

                case Hand.Free:
                    if (GameManager.instance.grabInteractors[0].SelectedInteractable == null)
                        GameManager.instance.grabInteractors[0].ForceSelect(interactable);
                    if (GameManager.instance.grabInteractors[1].SelectedInteractable == null)
                        GameManager.instance.grabInteractors[1].ForceSelect(interactable);
                    break;

            }
            Exit();
        }
    }

    public class SEvent_ForceDrop : SequenceEvent
    {
        //[SerializeField] Hand hand;
        [SerializeField] GrabInteractable interactable;
        [SerializeField] GameObject particleFX;

        public override void OnEnter()
        {
            base.OnEnter();
            if (GameManager.instance.grabInteractors[0].SelectedInteractable == interactable)
            {
                GameManager.instance.grabInteractors[0].ForceRelease();

                if (particleFX != null) // optional
                    Instantiate(particleFX, ControllerInteractionsManager.instance.leftHandAnchor.transform);
            }
            if (GameManager.instance.grabInteractors[1].SelectedInteractable == interactable)
            {
                GameManager.instance.grabInteractors[1].ForceRelease();

                if (particleFX != null) // optional
                    Instantiate(particleFX, ControllerInteractionsManager.instance.rightHandAnchor.transform);
            }
            Exit();
        }
    }

    public class SEvent_LerpPostProcessingWeight : SequenceEvent
    {
        [SerializeField] Volume postProcessingVolume;
        [SerializeField] float targetWeight;
        [SerializeField] float time;
        float timer;
        float startingWeight;

        public override void OnReset()
        {
            base.OnReset();
            timer = 0;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            startingWeight = postProcessingVolume.weight;
        }

        public override void Update()
        {
            base.Update();
            if ((timer += Time.deltaTime) < time)
                postProcessingVolume.weight = Mathf.Lerp(startingWeight, targetWeight, timer / time);
            else
                Exit();

        }

        public override void OnExit()
        {
            base.OnExit();
            postProcessingVolume.weight = targetWeight;
        }
    }

    public class SEvent_WaitForDistance : SequenceEvent
    {
        public enum DistanceCondition
        {
            LessThan,
            MoreThan
        }

        [SerializeField] GameObject gameObject1;
        [SerializeField] GameObject gameObject2;
        [SerializeField] DistanceCondition condition;
        [SerializeField] float distance;

        public override void OnEnter()
        {
            base.OnEnter();
            if ((gameObject1 == null) || (gameObject2 == null))
            {
                Exit();
                return;
            }
        }

        public override void Update()
        {
            base.Update();
            switch (condition)
            {
                case DistanceCondition.LessThan:
                    {
                        if (
                            (gameObject1.transform.position - gameObject2.transform.position).sqrMagnitude <
                            (distance * distance)
                        ) { Exit(); return; }
                        break;
                    }

                case DistanceCondition.MoreThan:
                    {
                        if (
                            (gameObject1.transform.position - gameObject2.transform.position).sqrMagnitude >
                            (distance * distance)
                        ) { Exit(); return; }
                        break;
                    }
            }

        }
    }

    public class SEvent_ChangeMaterialColor : SequenceEvent
    {
        [SerializeField] Material[] materials;
        [SerializeField] Color desiredColor;
        [SerializeField] bool emission;

        public override void OnEnter()
        {
            base.OnEnter();

            foreach (Material mat in materials)
            {
                mat.color = desiredColor;
                if (emission)
                    mat.EnableKeyword("_EMISSION");
                else
                    mat.DisableKeyword("_EMISSION");
            }
            Exit();
            return;
        }
    }
    
    public class SEvent_ChangeMaterialTexture : SequenceEvent
    {
        [SerializeField] Material[] currentMaterial;
        [SerializeField] Texture newTexture;

        public override void OnEnter()
        {
            base.OnEnter();

            foreach (Material mat in currentMaterial)
            {
                mat.mainTexture = newTexture;
            }
            Exit();
            return;
        }
    }
    public class SEvent_ChangeMaterial : SequenceEvent
    {
        [SerializeField] Renderer currentMaterial;
        [SerializeField] Material newMaterial;

        public override void OnEnter()
        {
            base.OnEnter();
            
            currentMaterial.material = newMaterial;

            Exit();
            return;
        }
    }

    public class SEvent_WaitForTrigger : SequenceEvent
    {
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void Update()
        {
            base.Update();

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Exit();
            }
            else
            {
                return;
            }
        }
    }
    public class SEvent_WaitForTargetPiece : SequenceEvent
    {
        [SerializeField] SaneChickenChopper chickenChopper;
        [SerializeField] int targetPiece;
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void Update()
        {
            base.Update();

            if (targetPiece == chickenChopper.currentCutIndex)
            {
                Exit();
                return;
            }
        }
    }
    public class SEvent_SetPosition : SequenceEvent
    {
        [SerializeField] GameObject target;
        [SerializeField] GameObject PositionSetTo;
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void Update()
        {
            base.Update();

            if (target != null && PositionSetTo != null)
            {
                target.transform.position = PositionSetTo.transform.position;
                Exit();
                return;
            }
        }
    }

    public class SEvent_InstantiateGO : SequenceEvent
    {
        [SerializeField] GameObject newGO;
        [SerializeField] Transform plasterSpawnPoint;
        public override void OnEnter()
        {
            base.OnEnter();
            Instantiate(newGO, plasterSpawnPoint.position, plasterSpawnPoint.rotation);
        }
    }

    public class SEvent_WaitGameObjectDestroy : SequenceEvent
    {
        [SerializeField] GameObject gameObject;

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void Update()
        {
            base.Update();
            if (gameObject == null)
            {
                Exit();
                return;
            }
        }
    }
    public class SEvent_WaitForFlag : SequenceEvent
    {
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void Update()
        {
            base.Update();
            if (GameManager.instance.flag == true)
            {
                GameManager.instance.flag = false;
                Exit();
                return;
            }
        }
    }

    public class SEvent_GoToSecondScenario : SequenceEvent
    {

        [SerializeField] TMP_Text debugText ;
        public override void OnEnter()
        {
            base.OnEnter();
            if (MainMenuManager.scenariosQueued.Count > 0)
            {
                string LevelName = "";
                switch (MainMenuManager.scenariosQueued.Dequeue())
                {
                    case "ScenarioA":
                        LevelName = "PastNegativeBathroom";
                        break;
                    case "ScenarioB":
                        LevelName = "PastPositiveBathroom";
                        break;
                    case "ScenarioC":
                        LevelName = "PresentBadBathroom";
                        break;
                    case "ScenarioD":
                        LevelName = "PresentGoodBathroom";
                        break;
                }
                if(debugText != null)
                    debugText.text = LevelName;
                SceneManager.LoadScene(LevelName);
            }
            else
            {
                if(debugText != null)
                    debugText.text = "No scenarios in queue";
                if(MainMenuManager.enableSurvey)
                    SceneManager.LoadScene("Survey");
                else
                {
                    //skip to thanks for playing.
                    SceneManager.LoadScene("ThanksForPlaying");
                }
                    
            }
            Exit();
        }
    }


    public class SEvent_SetRotation : SequenceEvent
    {
        [SerializeField] GameObject target;
        [SerializeField] Vector3 newRotation;

        public override void OnEnter()
        {
            base.OnEnter();
            if (target != null && newRotation != null)
            {
                target.transform.eulerAngles = newRotation;
            }
            Exit();
        }
    }

    public class SEvent_TriggerUnityEvent : SequenceEvent
    {
        [SerializeField] UnityEvent unityEvent;

        public override void OnEnter()
        {
            base.OnEnter();
            unityEvent.Invoke();
            Exit();
        }
    }

    public class SEvent_GoToScene : SequenceEvent
    {
        [SerializeField] string sceneName;

        public override void OnEnter()
        {
            base.OnEnter();
            SceneManager.LoadScene(sceneName);
            Exit();
        }
    }

    public class SEvent_AddToLevelsPlayedList : SequenceEvent
    {
        public override void OnEnter()
        {
            base.OnEnter();

            try
            {
                MainMenuManager.levelsPlayed.Add(SceneManager.GetActiveScene().name);
                Debug.Log("added " + SceneManager.GetActiveScene().name + " to levels played list");
            }
            catch (Exception e)
            {
                Debug.Log("failed to add to levels played list " + e);
            }
            
            Exit();
        }
    }



    // sequence manager properties
    public static SequenceManager _instance { get; private set; }

    [Header("Event Settings")]
#if UNITY_EDITOR
    [SerializeField] bool refreshEditor;
#endif
    [SerializeReference] private SequenceEvent[] events;
    UInt32 sequenceEventIndex = 0;



    // unity events
#if UNITY_EDITOR
    public void OnValidate()
    {
        refreshEditor = false;

        // go through each event and swap to appropriate child type
        for (int eventIndex = 0; eventIndex < events.Length; eventIndex++)
        {
            // check if event slot is filled
            if (events[eventIndex] == null)
            {
                events[eventIndex] = new SequenceEvent();
                continue;
            }

            // i miss pointers...
            System.Type desiredType = SequenceEvent.SequenceEventTypes[(int)events[eventIndex].type];

            // ignore this if the event type matches
            if (events[eventIndex].GetType() == desiredType) continue;
            SequenceEvent.SequenceEventEnum sequenceEventEnum = events[eventIndex].type;

            // event type DOESN'T match!! replace!!
            //delete events[eventIndex]; // i forgot c# doesn't let you deallocate memory directy... lame...
            string oldName = events[eventIndex].name;
            events[eventIndex] = (SequenceEvent)Activator.CreateInstance(desiredType);
            events[eventIndex].type = sequenceEventEnum;
            events[eventIndex].name = oldName;

            // debug
            //Debug.Log("Replacing sequence event at index " + eventIndex.ToString() + " with a sequence event of type " + SequenceEvent.SequenceEventTypes[(int)events[eventIndex].type].ToString());

        }

    }
#endif

    private void Start()
    {
        if ((events == null) || (events.Length <= 0)) return; // end here if there are no events to play
        _instance = this;

        // set up the first event
        events[sequenceEventIndex].Reset();
        events[sequenceEventIndex].OnEnter();

    }

    private void Update()
    {
        if ((events == null) || (events.Length <= sequenceEventIndex)) return; // end here if there are no events to play

        // dispatch event update
        events[sequenceEventIndex].Update();

        // check if event wants to end
        if (!events[sequenceEventIndex].exitFlag) return;

        // exit current event
        events[sequenceEventIndex++].OnExit();

        // enter next event
        if (events.Length <= sequenceEventIndex) return; // end here if there are no events to play
        events[sequenceEventIndex].Reset();
        events[sequenceEventIndex].OnEnter();
    }


}
