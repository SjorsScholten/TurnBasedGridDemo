using System.Collections.Generic;

namespace HinosDeveloperConsole {
    public class ConsoleController {
        private readonly Dictionary<string, Command> _commands = new Dictionary<string, Command>();
        private readonly DeveloperConsole _console;

        public ConsoleController() {
            this._console = DeveloperConsole.Instance;
            Initialize();
        }

        public void Initialize() {
            Command logCOmmand = new LogCommand();
            _commands.Add(logCOmmand.Name, logCOmmand);
        }

        public void ProcessCommand(string commandLine) {
            string[] message = commandLine.Split(' ');
            
            if (message.Length == 0 || !_commands.ContainsKey(message[0])) {
                _console.PrintLine("Command is not recognized");
                return;
            }
            
            _commands[message[0]].Run(message);
        }
    }
}