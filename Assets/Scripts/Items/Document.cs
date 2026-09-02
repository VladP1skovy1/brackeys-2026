using AntiqueShop.Lighting;
using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Document", menuName = "Scriptable Objects/Document")]
    public class Document : Item, IInscribed, IUVReactive
    {
        [field: SerializeField] public string DocumentText { get; private set; }
        [field: SerializeField] public Sprite DocumentSprite { get; private set; }
        [field: SerializeField] public bool IsUVReactive { get; private set; }
        [field: SerializeField] public Sprite UVDocumentSprite { get; private set; }
        [field: SerializeField] public LightShapeType LightShape { get; private set; }
        [field: SerializeField] public Color GlowColor { get; private set; }
        

        Sprite IInscribed.CloseUp => DocumentSprite;
        Sprite IUVReactive.UVView => UVDocumentSprite;
        LightShapeType IUVReactive.LightShape => LightShape;
        Color IUVReactive.GlowColor => GlowColor;
    }
}
