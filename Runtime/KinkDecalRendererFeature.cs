using UnityEngine.Rendering.Universal;

namespace kTools.Decals
{
    sealed class KinkDecalRendererFeature : ScriptableRendererFeature
    {
#region Fields
        static KinkDecalRendererFeature s_Instance;
        readonly KinkDecalRenderPass m_RenderPass;
#endregion

#region Constructors
        public KinkDecalRendererFeature()
        {
            s_Instance = this;
            m_RenderPass = new KinkDecalRenderPass();
        }
#endregion

#region Initialization
        public override void Create()
        {
            name = "Decals";
        }
#endregion
        
#region RenderPass
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            // Enqueue passes
            renderer.EnqueuePass(m_RenderPass);
        }
#endregion
    }
}
