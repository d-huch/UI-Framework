using UnityEngine;

namespace Modules.UIFramework
{
    public class PanelView: MonoBehaviour
    {
        [SerializeField] private PanelType panelType;
        [SerializeField] private ViewConfig viewConfig;
        
        public PanelType PanelType => panelType;
        public ViewConfig ViewConfig => viewConfig;
        public Canvas Canvas { get; private set; }

        public void SetCanvas(Canvas canvas)
        {
            Canvas = canvas;
        }
    }
}