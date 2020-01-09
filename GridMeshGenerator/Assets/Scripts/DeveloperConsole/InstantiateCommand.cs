namespace HinosDeveloperConsole {
    public class InstantiateCommand : Command {
        public override string Name { get; protected set; } = "Instantiate";
        public override string Description { get; protected set; } = "Spawn an object into the game";
        public override string Help { get; protected set; } = "Instantiate <object> <position(x,y,z)>";
        
        public override void Run(string[] arg) {
            throw new System.NotImplementedException();
        }
    }
}