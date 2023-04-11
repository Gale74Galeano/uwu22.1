using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorInvertFeature : ScriptableRendererFeature
{
    class CustomRenderPass : ScriptableRenderPass
    {
        //ID de la imagen que guarda el pantallazo
        private RenderTargetHandle screenShootTarget;
        private Material renderingMaterial;

        public CustomRenderPass(Material renderingMaterial)
        {
            //Se inicializa el ID
            screenShootTarget.Init("_ColorInvertTexture");
            //Asignamos material del feature
            this.renderingMaterial = renderingMaterial;
        }


        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {

        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            //Lista de comando para ejecutar a la hora de renderizar
            CommandBuffer cmd = CommandBufferPool.Get("Invert Colors");
            RenderTextureDescriptor screenDescriptor = renderingData.cameraData.cameraTargetDescriptor;
            //Crear textura
            cmd.GetTemporaryRT(screenShootTarget.id, screenDescriptor);
            //Tomar pantallazo
            cmd.Blit(renderingData.cameraData.renderer.cameraColorTarget, screenShootTarget.Identifier(), renderingMaterial, renderingMaterial.FindPass("Universal Forward"));
            cmd.Blit(screenShootTarget.Identifier(), renderingData.cameraData.renderer.cameraColorTarget);
            context.ExecuteCommandBuffer(cmd);
        }

        public override void OnCameraCleanup(CommandBuffer cmd)
        {

        }
    }

    CustomRenderPass m_ScriptablePass;
    [SerializeField] private RenderPassEvent renderEvent;
    [SerializeField] private Material renderingMaterial;

    /// <inheritdoc/>
    public override void Create()
    {
        m_ScriptablePass = new CustomRenderPass(renderingMaterial);

        // Configures where the render pass should be injected.
        m_ScriptablePass.renderPassEvent = renderEvent;
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}