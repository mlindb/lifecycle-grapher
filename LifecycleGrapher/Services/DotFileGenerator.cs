using System.Text;
using LifecycleGrapher.Models;

namespace LifecycleGrapher.Services
{
    public class DotFileGenerator
    {
        public string GenerateDotFile(ApiResponseModel data, string graphName)
        {
            var dotBuilder = new StringBuilder();
            dotBuilder.AppendLine($"digraph {graphName} {{");

            // Add states as nodes
            foreach (var state in data.States)
            {
                dotBuilder.AppendLine($"    \"{state.Id}\" [label=\"{state.Name}\"];");
            }

            // Add transitions as edges
            foreach (var state in data.States)
            {
                foreach (var transition in state.Transitions)
                {
                    dotBuilder.AppendLine($"    \"{transition.From}\" -> \"{transition.To}\" [label=\"{transition.Name}\"];");
                }
            }

            dotBuilder.AppendLine("}");
            return dotBuilder.ToString();
        }
    }
}
