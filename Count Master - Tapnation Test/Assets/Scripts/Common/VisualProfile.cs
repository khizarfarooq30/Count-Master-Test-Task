using UnityEngine;

public class VisualProfile : MonoBehaviour
{
   [SerializeField] private SkinnedMeshRenderer meshRenderer;
   [SerializeField] private Color baseColor;
   [SerializeField] private Color emissiveColor;

   private void Start()
   {
      MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
      
      materialPropertyBlock.SetColor("_BaseColor", baseColor);
      materialPropertyBlock.SetColor("_EmissionColor", emissiveColor);
      
      meshRenderer.SetPropertyBlock(materialPropertyBlock);
   }
}
