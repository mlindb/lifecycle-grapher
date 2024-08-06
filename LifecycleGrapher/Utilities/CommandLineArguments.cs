namespace LifecycleGrapher.Utilities
{
    public class CommandLineArguments
    {
        public string Url { get; private set; }
        public string ObjectName { get; private set; }

        public CommandLineArguments(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Insufficient arguments provided. Usage: LifecycleGrapher <url> <objectName>");
            }

            Url = args[0];
            ObjectName = args[1];
        }
    }
}
