using System;
using UnityEngine;
using Zenject;

namespace Modules.UIFramework.Interface
{
    public interface IPanelView
    {
        PanelType PanelType { get; }
        Type Setup(DiContainer container, PanelView viewPrefab);
        void Bind(DiContainer container, Type type);
    }
}