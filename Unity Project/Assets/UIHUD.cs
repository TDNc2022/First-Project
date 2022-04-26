using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
namespace FirstProject{
    public class UIHUD : MonoBehaviour
    {
        private Transform player;
        private VisualElement hpOverlay;
        private VisualElement hpBackground;
        private Label hpText;
        private Label timer;
        private Label waveTimer;
        private Label waveState;
        private Label waveCurrent;
        private Label enemies;
        private float maxHP;
        private float currentHP;
        public string currentWave;
        private string currentState;
        private float remaningEnemies;
        // Start is called before the first frame update
        void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            hpOverlay = root.Q("Overlay");
            hpText = root.Q<Label>("info-display");
            timer = root.Q<Label>("timer");
            waveState = root.Q<Label>("status");
            waveCurrent = root.Q<Label>("waves");
            enemies = root.Q<Label>("enemies");
        }

        // Update is called once per frame
        void Update()
        {
            player = PlayerController.Instance.transform;
            Stats(); //setter & getter de stats
            HUDInfo(); //hud display
        }
        private static float HPPercentage(float current, float max){ //Convierte el HP en porcentaje
            float healthP = (current/max) * 100;
            return healthP;
        }
        private void Stats(){
            maxHP = player.GetComponent<CharBody>().MaxHealth;
            currentHP = player.GetComponent<CharBody>().CurrentHealth;
            currentWave = GetComponent<WaveManager>()._currentWave;
            currentState = GetComponent<WaveManager>()._currentState;

        }
        private void HUDInfo(){
            HP(); //setter & getter de hp
            Wave();
            Timer();
        }
        private void HP(){
            hpOverlay.style.width = new StyleLength(Length.Percent(HPPercentage(currentHP, maxHP)));
            hpText.text = currentHP + "/" + maxHP;
        }
        private void Wave(){
            if (currentWave == "")
            {
                waveCurrent.style.display = DisplayStyle.None;
                waveState.style.display = DisplayStyle.None;
                return;
            }
            else
            {
            waveCurrent.style.display = DisplayStyle.Flex;
            waveState.style.display = DisplayStyle.Flex;
            waveCurrent.text = "Wave #" + currentWave;
            waveState.text = currentState;
            }
        }
        private void Timer(){
            float t = Time.time;

            string minutes = ((int) t /60).ToString();
            string seconds = (t % 60).ToString("f2");
            
            timer.text = minutes+":"+seconds;
        }
}
}