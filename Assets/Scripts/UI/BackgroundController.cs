using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class BackgroundController : MonoBehaviour
    {
        public Sprite GetBackGroundSprite()
        {
            var image = GetComponent<Image>();
            return image.sprite;
        }

        public int GetPrice()
        {
            var priceText = GetComponentInChildren<TextMeshProUGUI>();
            var price = Convert.ToInt32(priceText.text);
            return price;
        }
    }
}