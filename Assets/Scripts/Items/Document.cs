using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Document", menuName = "Scriptable Objects/Document")]
    public class Document : Item, IInscribed, IUVReactive
    {
        [field: SerializeField] public string DocumentText { get; private set; }
        [field: SerializeField] public bool IsUVReactive { get; private set; }
        [field: SerializeField] public Sprite UVDocumentSprite { get; private set; }

        string IInscribed.Text => DocumentText;
        Sprite IUVReactive.UVView => UVDocumentSprite;
    }
}
