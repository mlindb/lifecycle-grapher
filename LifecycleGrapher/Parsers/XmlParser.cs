using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LifecycleGrapher.Models;

namespace LifecycleGrapher.Parsers
{
    public class XmlParser
    {
        public ApiResponseModel ParseData(string xmlData)
        {
            var xDocument = XDocument.Parse(xmlData);
            var resourceElement = xDocument.Element("resource");
            if (resourceElement == null)
            {
                throw new InvalidOperationException("The XML data does not contain a 'resource' element.");
            }

            var apiResponseModel = new ApiResponseModel
            {
                ResourceName = resourceElement.Attribute("name")?.Value ?? string.Empty,
                Attributes = resourceElement.Element("attributes")?
                    .Elements("attribute")
                    .Select(a => new AttributeModel
                    {
                        Name = a.Attribute("name")?.Value ?? string.Empty,
                        Type = a.Attribute("type")?.Value ?? string.Empty,
                        Searchable = bool.Parse(a.Attribute("searchable")?.Value ?? "false")
                    }).ToList() ?? new List<AttributeModel>(),
                States = resourceElement.Element("lifecycle")?
                    .Element("states")?
                    .Elements("state")
                    .Select(s => new StateModel
                    {
                        Id = int.Parse(s.Attribute("id")?.Value ?? "0"),
                        Name = s.Attribute("name")?.Value ?? string.Empty,
                        Deleted = s.Attribute("deleted") != null && bool.Parse(s.Attribute("deleted")?.Value ?? "false"),
                        Transitions = new List<TransitionModel>()
                    }).ToList() ?? new List<StateModel>()
            };

            var transitions = resourceElement.Element("lifecycle")?
                .Element("transitions")?
                .Elements("transition")
                .Select(t => new TransitionModel
                {
                    Id = int.Parse(t.Attribute("id")?.Value ?? "0"),
                    Name = t.Attribute("name")?.Value ?? string.Empty,
                    From = int.Parse(t.Attribute("from")?.Value ?? "0"),
                    To = int.Parse(t.Attribute("to")?.Value ?? "0")
                }).ToList() ?? new List<TransitionModel>();

            // Map transitions to their respective states
            foreach (var state in apiResponseModel.States)
            {
                state.Transitions = transitions.Where(t => t.From == state.Id).ToList();
            }

            return apiResponseModel;
        }
    }
}