using System.Collections.Generic;

namespace LifecycleGrapher.Models
{
    public class ApiResponseModel
    {
        public string ResourceName { get; set; } = string.Empty;
        public List<AttributeModel> Attributes { get; set; } = new List<AttributeModel>();
        public List<StateModel> States { get; set; } = new List<StateModel>();
    }

    public class AttributeModel
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool Searchable { get; set; }
    }

    public class StateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Deleted { get; set; }
        public List<TransitionModel> Transitions { get; set; } = new List<TransitionModel>();
    }

    public class TransitionModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int From { get; set; }
        public int To { get; set; }
    }
}
