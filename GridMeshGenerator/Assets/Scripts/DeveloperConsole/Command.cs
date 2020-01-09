namespace HinosDeveloperConsole {
    public abstract class Command {
        public abstract string Name { get; protected set; }
        public abstract string Description { get; protected set; }
        public abstract string Help { get; protected set; }

        public abstract void Run(string[] arg);
    }
}