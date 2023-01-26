using System;
using Zenject;

namespace Modules.UIFramework.Interface
{
    public interface IPanel
    {
        void Setup(DiContainer container, IPanelView view);
        Type ControllerType { get; }
    }
}