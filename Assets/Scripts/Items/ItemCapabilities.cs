using AntiqueShop.Utils;
using UnityEngine;

namespace AntiqueShop.Items
{
    public interface IWeighable
    {
        float Weight { get; }
    }

    public interface IMeasurable
    {
        Vector2 Dimensions { get; }
    }

    public interface IMagnetic
    {
        bool IsMagnetic { get; }
    }

    public interface IInscribed
    {
        Sprite CloseUp { get; }
    }

    public interface IUVReactive
    {
        bool IsUVReactive { get; }
        Sprite UVView { get; }
        LightShapeType LightShape { get; }
        Color GlowColor { get; }
    }
}
