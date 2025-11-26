using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Mirror : MonoBehaviour
{
    public Camera mainCamera;
    public Camera reflectionCamera;
    public RenderTexture reflectionTexture;

    private void LateUpdate()
    {
        if (!mainCamera || !reflectionCamera || !reflectionTexture)
            return;

        // Mirror plane
        Vector3 pos = transform.position;
        Vector3 normal = transform.up;

        // Reflect camera position
        Vector3 d = mainCamera.transform.position - pos;
        Vector3 reflectedPos = mainCamera.transform.position - 2 * Vector3.Dot(d, normal) * normal;

        reflectionCamera.transform.position = reflectedPos;

        // Reflect camera rotation
        Vector3 forward = Vector3.Reflect(mainCamera.transform.forward, normal);
        Vector3 up = Vector3.Reflect(mainCamera.transform.up, normal);
        reflectionCamera.transform.rotation = Quaternion.LookRotation(forward, up);

        // Render into texture
        reflectionCamera.targetTexture = reflectionTexture;
        reflectionCamera.Render();
    }
}
