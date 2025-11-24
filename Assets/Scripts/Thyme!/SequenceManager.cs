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
			[InspectorName("None")				] SET_None				,
			[InspectorName("Text")				] SET_Text				,
			[InspectorName("Wait")				] SET_WaitSeconds		,
			[InspectorName("Wait for pickup")	] SET_WaitForItemPickup	,
			[InspectorName("Wait for drop")		] SET_WaitForItemDrop	,
			[InspectorName("")					] SET_COUNT // NOT an actual type! here for easy counting!!!
		}

		public static readonly System.Type[] SequenceEventTypes = new System.Type[(int)SequenceEventEnum.SET_COUNT]
		{
			typeof(SequenceEvent            ),
			typeof(SEvent_Text              ),
			typeof(SEvent_WaitSeconds       ),
			typeof(SEvent_WaitForItemPickup ),
			typeof(SEvent_WaitForItemDrop   ),
		};

		public SequenceEventEnum type;
#endif
	}

    [Serializable]
    public class SEvent_Text : SequenceEvent
	{
		[SerializeField] string SEvent_TextString;
	}

    [Serializable]
    public class SEvent_WaitSeconds : SequenceEvent
	{
		[SerializeField] int SEvent_WaitSecondsSeconds;
	}

	public class SEvent_WaitForItemPickup : SequenceEvent 
	{

	}

	public class SEvent_WaitForItemDrop : SequenceEvent
	{

	}





	// sequence manager properties
	[SerializeReference] private SequenceEvent[] events;



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
            Debug.Log("Replacing sequence event at index " + eventIndex.ToString() + " with a sequence event of type " + SequenceEvent.SequenceEventTypes[(int)events[eventIndex].type].ToString());

        }
		
	}
#endif 


}
