using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
namespace FirstProject{
    public class UIHUD : MonoBehaviour
    {
        public VisualElement hpOverlay;
        public VisualElement hpBackground;
        private Label hpText;
        public float maxHP;
        public float currentHP;
        // Start is called before the first frame update
        void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            hpOverlay = root.Q("Overlay");
            hpText = root.Q<Label>("info-display");
        }

        // Update is called once per frame
        void Update()
        {
            Stats(); //setter & getter de stats
            HUDInfo(); //hud display
        }
        private static float HPPercentage(float current, float max){ //Convierte el HP en porcentaje
            float healthP = (current/max) * 100;
            return healthP;
        }
        private void Stats(){
            maxHP = GetComponent<CharBody>().MaxHealth;
            currentHP = GetComponent<CharBody>().CurrentHealth;
        }
        private void HUDInfo(){
            HP(); //setter & getter de hp
        }
        private void HP(){
            hpOverlay.style.width = new StyleLength(Length.Percent(HPPercentage(currentHP, maxHP)));
            hpText.text = currentHP + "/" + maxHP;
        }
}
}