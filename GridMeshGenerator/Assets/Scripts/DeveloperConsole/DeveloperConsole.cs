using System.Collections;
using HinosPackage.Runtime.Util;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HinosDeveloperConsole {
    public class DeveloperConsole : Singleton<DeveloperConsole> {

        private ConsoleController _controller;
        
        [Header(("UI Elements"))] 
        [SerializeField] private Text consoleText;
        [SerializeField] private ScrollRect consoleRect;
        [SerializeField] private InputField consoleInput;
    
        private void Awake() {
            _controller = new ConsoleController();
        }

        public void Submit() {
            ProcessCommandLine(consoleInput.text);
        }

        public void ProcessCommandLine(string commandLine) {
            _controller.ProcessCommand(commandLine);
        }
    
        public void PrintLine(string text) {
            consoleText.text += text + "/n";
            consoleRect.verticalNormalizedPosition = 0f;
        }
    }
}

