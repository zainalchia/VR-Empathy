using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{

	// sequence event class defines
	[Serializable]
	public class SequenceEvent
	{
#if UNITY_EDITOR // this is an editor utility ONLY, for swapping between sequence event types
		public enum SequenceEventEnum
		{
			[InspectorName("None")					] SET_None				,
			[InspectorName("Show Prompt")			] SET_Text				,
			[InspectorName("Wait")					] SET_WaitSeconds		,
			[InspectorName("Wait for item pickup")	] SET_WaitForItemPickup	,
			[InspectorName("Wait for item drop")	] SET_WaitForItemDrop	,
			[InspectorName("Play audio")			] SET_PlayAudioClip		,
			[InspectorName("")						] SET_COUNT // NOT an actual type! here for easy counting!!!
		}

		public static readonly System.Type[] SequenceEventTypes = new System.Type[(int)SequenceEventEnum.SET_COUNT]
		{
			typeof(SequenceEvent            ),
			typeof(SEvent_Text              ),
			typeof(SEvent_WaitSeconds       ),
			typeof(SEvent_WaitForItemPickup ),
			typeof(SEvent_WaitForItemDrop   ),
			typeof(SEvent_PlayAudio			),
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
		[SerializeField] Grabbable grabbable;

		public override void Update()
		{
			base.Update();
			if (ThymeVRUtility.IsHeld(grabbable))
				Exit();
		}
	}

	public class SEvent_WaitForItemDrop : SequenceEvent
	{
		[SerializeField] Grabbable grabbable;

		public override void Update()
		{
			base.Update();
			if (!ThymeVRUtility.IsHeld(grabbable))
				Exit();
		}
	}

	public class SEvent_PlayAudio : SequenceEvent
	{
		[SerializeField] AudioSource audioSource;
		[SerializeField] AudioClip audioClip;
		[SerializeField] bool waitForEnd = true;

		public override void OnEnter()
		{
			base.OnEnter();
			audioSource.loop = false;
			audioSource.Stop();
			audioSource.clip = audioClip;
			audioSource.Play();
		}

		public override void Update()
		{
			base.Update();
			if (waitForEnd && audioSource.isPlaying) return; // ignore if we want to wait for the end AND the audio source is playing
			Exit();
		}

	}





	// sequence manager properties
	[SerializeReference] private SequenceEvent[] events;
	UInt32 sequenceEventIndex = 0;



	// unity events
#if UNITY_EDITOR
	public void OnValidate()
	{
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
			events[eventIndex] = (SequenceEvent)Activator.CreateInstance(desiredType);
			events[eventIndex].type = sequenceEventEnum;

			// debug
			//Debug.Log("Replacing sequence event at index " + eventIndex.ToString() + " with a sequence event of type " + SequenceEvent.SequenceEventTypes[(int)events[eventIndex].type].ToString());

		}
		
	}
#endif

	private void Start()
	{
		if ((events == null) || (events.Length <= 0)) return; // end here if there are no events to play

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
