using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
namespace FirstProject
{
    public class UIController : MonoBehaviour
    {

        public Button startButton;
        public Button textButton;
        public Label textMessage;
        private bool isText;
        // Start is called before the first frame update
        void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            startButton = root.Q<Button>("start-button");
            textButton = root.Q<Button>("text-button");
            textMessage = root.Q<Label>("text-message");

            startButton.clicked += StartButtonPressed;
            textButton.clicked += ButtonPressed;
        }
        void StartButtonPressed(){
            SceneManager.LoadScene("game");
        }
        void ButtonPressed(){
            // if (isText == false)
            // {
            // textMessage.text = "Aguante el Colo!";
            // textMessage.style.display = DisplayStyle.Flex;
            // isText = true;
            // return;
            // }
            // textMessage.style.display = DisplayStyle.None;
            // isText = false;
            Difficulty _selectedDifficulty = FirstProjectApp.Instance.selectedDifficulty;
        }
    }
}