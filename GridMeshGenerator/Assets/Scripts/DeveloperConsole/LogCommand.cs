using UnityEngine;

namespace HinosDeveloperConsole {
    public class LogCommand : Command {
        public override string Name { get; protected set; } = "Log";
        public override string Description { get; protected set; } = "send a log command to the unity console";
        public override string Help { get; protected set; } = "Log <text>";
        
        public override void Run(string[] arg) {
            Debug.Log(arg[1]);
        }
    }
}