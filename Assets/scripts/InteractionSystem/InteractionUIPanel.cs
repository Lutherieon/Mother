using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace VHS
{
    public class InteractionUIPanel : MonoBehaviour
    {
      [SerializeField] UnityEngine.UI.Image Image;





        public void UpdateProgressBar(float fillAmount)
        {
            Image.fillAmount = fillAmount;

        }

        public void Reset()
        {
            Image.fillAmount = 0;
        }
    }
}
