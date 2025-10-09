using UnityEngine;
using EzySlice;

public class SlicedObject : MonoBehaviour
{
    public Transform StartSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;

    public Material crossSectionMaterial;
    public float cutForce = 35f;

    [Tooltip("How many slices a brand-new object may take before it becomes un­sliceable.")]
    public int maxCuts = 8;

    void FixedUpdate()
    {
        if (Physics.Linecast(StartSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer))
        {
            var go = hit.transform.gameObject;

            var limit = go.GetComponent<SliceLimit>();
            int cutsLeft = (limit != null) ? limit.remainingCuts : maxCuts;

            if (cutsLeft > 0)
                Slice(go, cutsLeft - 1);
        }
    }

    public void Slice(GameObject target)
    {
        Slice(target, maxCuts - 1);
    }

    public void Slice(GameObject target, int remainingCuts)
    {
        var velocity = velocityEstimator.GetVelocityEstimate();
        var planeNormal = Vector3.Cross(endSlicePoint.position - StartSlicePoint.position, velocity).normalized;

        var hull = target.Slice(endSlicePoint.position, planeNormal);
        if (hull == null) return;

        ConfigureSliceable(hull.CreateUpperHull(target, crossSectionMaterial), target.layer, remainingCuts);
        ConfigureSliceable(hull.CreateLowerHull(target, crossSectionMaterial), target.layer, remainingCuts);

        Destroy(target);
    }

    private void ConfigureSliceable(GameObject piece, int layer, int remainingCuts)
    {
        piece.layer = layer;

        var rb = piece.AddComponent<Rigidbody>();
        var mc = piece.AddComponent<MeshCollider>();
        mc.convex = true;
        rb.AddExplosionForce(cutForce, piece.transform.position, 1);

        var limit = piece.AddComponent<SliceLimit>();
        limit.remainingCuts = remainingCuts;
    }
}
