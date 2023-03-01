using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentColorManager : MonoBehaviour
{
    [SerializeField] private Material groundMat;
    [SerializeField] public Material borderMat;
    [SerializeField] private Material fogMat;
    [SerializeField] private Material cubeMat;

    [SerializeField] private LevelColor[] levelColors;
    
    private static readonly int Color58E0201D = Shader.PropertyToID("Color_58E0201D");

    private void Start()
    {
        int randomIndex = Random.Range(0, levelColors.Length);

        groundMat.color = levelColors[randomIndex].groundColor;
        borderMat.color = levelColors[randomIndex].borderColor;
        cubeMat.color = levelColors[randomIndex].cubeColor;
        fogMat.SetColor(Color58E0201D, levelColors[randomIndex].fogColor);
    }
} 


[Serializable]
public class LevelColor
{
    public Color groundColor;
    public Color borderColor;
    public Color fogColor;
    public Color cubeColor;
}