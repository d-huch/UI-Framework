using UnityEngine;

namespace Modules.UIFramework
{
    public class PanelView: MonoBehaviour
    {
        [SerializeField] private string panelName;
        [SerializeField] private ViewConfig viewConfig;
        
        public string PanelType => panelName;
        public ViewConfig ViewConfig => viewConfig;
        public Canvas Canvas { get; private set; }

        public void SetCanvas(Canvas canvas)
        {
            Canvas = canvas;
        }
    }
}