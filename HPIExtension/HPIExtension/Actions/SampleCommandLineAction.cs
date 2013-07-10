using System;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;

namespace HPIExtension.Actions
{
    [ActionProperties(
        "Basic CommandLineActionBase Action",
        "An action that demonstrates CommandLineActionBase usage by wrapping cmd.exe to echo the specified text.",
        "HPI")]
    public sealed class SampleCommandLineAction : CommandLineActionBase
    {
        /// <summary>
        /// Gets or sets the text to echo to cmd.exe.
        /// </summary>
        [Persistent]
        public string TextToEcho { get; set; }

        protected override void Execute()
        {
            // the ExecuteCommandLine method will execute the specified command on the agent
            var returnCode =  this.ExecuteCommandLine(
                "cmd.exe",
                "/c echo " + this.TextToEcho,
                this.RemoteConfiguration.SourceDirectory);
        }

        protected override string ProcessRemoteCommand(string name, string[] args)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Echos \"" + this.TextToEcho + "\" via cmd.exe.";
        }
    }
}
