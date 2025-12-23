using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaneChickenChopper : MonoBehaviour
{
    [Header("Blendshape References")]
    public SkinnedMeshRenderer chickenMesh;
    public List<int> blendShapeIndices;
    public float blendLerpTime = 0.25f;

    [Header("Cut Line Objects (Pre-Placed)")]
    public List<GameObject> cutLines;

    public int currentCutIndex = 0;

    private void Update()
    {
        for (int i = 0; i < cutLines.Count; i++)
        {
            cutLines[i].SetActive(i == currentCutIndex);
            chickenMesh.SetBlendShapeWeight(i, 0);
        }
    }

    private IEnumerator LerpBlendShape(int index, float start, float end, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            float val = Mathf.Lerp(start, end, t / duration);
            chickenMesh.SetBlendShapeWeight(index, val);
            t += Time.deltaTime;
            yield return null;
        }
        chickenMesh.SetBlendShapeWeight(index, end);
    }

    public void Reset()
    {
        currentCutIndex = 0;
    }

    public void NextCut()
    {
        StartCoroutine(LerpBlendShape(currentCutIndex, 0, 100, blendLerpTime));
        currentCutIndex++;
    }




}
