using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIApplication.Interfaces;

namespace DIApplication.Implementation
{
    public class ObjectType : IObjectType
    {
        public string Name { get; private set; }

        public string Code { get; private set; }

        public string Description { get; private set; }

        public ObjectType(string name, string code, string description)
        {
            Name = name;
            Code = code;
            Description = description;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetCode()
        {
            return Code;
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}
