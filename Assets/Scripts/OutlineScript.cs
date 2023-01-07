using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class OutlineScript : MonoBehaviour
{
    // The material for the outline
    public Material outlineMaterial;

    // The color of the outline
    public Color outlineColor = Color.red;

    // The width of the outline
    public float outlineWidth = 0.1f;

    public Camera camera;
    
    // The command buffer for rendering the outline
    private CommandBuffer commandBuffer;

    void Start()
    {
        // Set the color and width of the outline
        outlineMaterial.SetColor("_Color", outlineColor);
        outlineMaterial.SetFloat("_OutlineWidth", outlineWidth);

        // Create the command buffer for rendering the outline
        commandBuffer = new CommandBuffer();
        commandBuffer.name = "Outline";
        commandBuffer.Blit(BuiltinRenderTextureType.CurrentActive, BuiltinRenderTextureType.CurrentActive, outlineMaterial);

        // Add the command buffer to the camera's execution list
        Camera.main.AddCommandBuffer(CameraEvent.AfterForwardOpaque, commandBuffer);
    }

    void OnDestroy()
    {
        // Remove the command buffer from the camera's execution list
        Camera.main.RemoveCommandBuffer(CameraEvent.AfterForwardOpaque, commandBuffer);
    }
}
