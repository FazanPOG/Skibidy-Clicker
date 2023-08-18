using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class MeshCombiner : MonoBehaviour
{
    public void CombineMeshes()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();
        meshFilter.mesh.CombineMeshes(combine, true);

        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterials = GetMaterials();
    }
    private Material[] GetMaterials()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        Material[] materials = new Material[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            materials[i] = renderers[i].sharedMaterial;
        }

        return materials;
    }
}
