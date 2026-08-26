using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Alcohol", menuName = "Scriptable Objects/Alcohol")]
    public class Alcohol : Item, IInscribed
    {
        [field: SerializeField] public string AlcoholText { get; private set; }

        string IInscribed.Text => AlcoholText;
    }
}
