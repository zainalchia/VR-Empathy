using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerTeleport))]
public class PlayerTeleportEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlayerTeleport teleport = (PlayerTeleport)target;

        GUILayout.Space(10);
        GUI.backgroundColor = Color.green;

        if (GUILayout.Button("Simulate Teleport Step"))
        {
            SimulateTeleportStep(teleport);
        }
    }

    private void SimulateTeleportStep(PlayerTeleport teleport)
    {
        int currentIndex = teleport.GetCurrentHotspotIndex();

        if (GameManager.instance.scenarioID == ScenarioID.PresentGood)
        {
            if (teleport.MovingToLivingRoom)
            {
                var hotspots = teleport.GetMoveToLivingRoomHotspots();
                if (currentIndex < hotspots.Length - 1)
                {
                    currentIndex += 1;
                    teleport.SetCurrentHotspotIndex(currentIndex);
                    teleport.MoveToLocation(hotspots[currentIndex], hotspots);
                }
            }
            else if (teleport.MovingToMainDoor)
            {
                var hotspots = teleport.GetMoveToMainDoorHotspots();
                if (currentIndex < hotspots.Length - 1)
                {
                    currentIndex += 1;
                    teleport.SetCurrentHotspotIndex(currentIndex);
                    teleport.MoveToLocation(hotspots[currentIndex], hotspots);
                }
            }
            else if (teleport.MovingToCheckersChair)
            {
                var hotspots = teleport.GetMoveToCheckersChairHotspots();
                if (currentIndex < hotspots.Length - 1)
                {
                    currentIndex += 1;
                    teleport.SetCurrentHotspotIndex(currentIndex);
                    teleport.MoveToLocation(hotspots[currentIndex], hotspots);
                }
            }
            else if (teleport.MovingToKaraokeCorner)
            {
                var hotspots = teleport.GetMoveToKaraokeCornerHotspots();
                if (currentIndex < hotspots.Length - 1)
                {
                    currentIndex += 1;
                    teleport.SetCurrentHotspotIndex(currentIndex);
                    teleport.MoveToLocation(hotspots[currentIndex], hotspots);
                }
            }
        }
        else if (GameManager.instance.scenarioID == ScenarioID.PastNegative)
        {
            if (teleport.MoveToToiletDoor)
            {
                var hotspots = teleport.GetMoveToToiletDoorHotspots();
                if (currentIndex < hotspots.Length - 1)
                {
                    currentIndex += 1;
                    teleport.SetCurrentHotspotIndex(currentIndex);
                    teleport.MoveToLocation(hotspots[currentIndex], hotspots);
                }
            }
            else if (teleport.MoveToHawkerStall)
            {
                var hotspots = teleport.GetMoveToHawkerStallHotspots();
                if (currentIndex < hotspots.Length - 1)
                {
                    currentIndex += 1;
                    teleport.SetCurrentHotspotIndex(currentIndex);
                    teleport.MoveToLocation(hotspots[currentIndex], hotspots);
                }
            }
            else if (teleport.MoveToTable)
            {
                var hotspots = teleport.GetMoveToTableHotspots();
                if (currentIndex < hotspots.Length - 1)
                {
                    currentIndex += 1;
                    teleport.SetCurrentHotspotIndex(currentIndex);
                    teleport.MoveToLocation(hotspots[currentIndex], hotspots);
                }
            }
            else if (teleport.MoveToSection)
            {
                var hotspots = teleport.GetMoveToJobPositionHotspots();
                if (currentIndex < hotspots.Length - 1)
                {
                    currentIndex += 1;
                    teleport.SetCurrentHotspotIndex(currentIndex);
                    teleport.MoveToLocation(hotspots[currentIndex], hotspots);
                }
            }
        }
        else
        {
            Debug.LogWarning("Unsupported ScenarioID or missing movement flags.");
        }
    }
}
