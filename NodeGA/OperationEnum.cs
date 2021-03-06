﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    public class OperationEnum
    {


        public static OperationEnum ADD = new OperationEnum("ADD", v => v[0] + v[1]);

        public static OperationEnum SUB = new OperationEnum("SUB", v => v[0] - v[1]);

        public static OperationEnum MUL = new OperationEnum("MUL", v => v[0] * v[1]);

        public static OperationEnum DIV = new OperationEnum("DIV", v => v[0] / v[1]);


        public string Name { get; private set; }

        public Func<int[], int> Func { get; private set; }

        public OperationEnum(string name, Func<int[], int> func)
        {
            Name = name;
            Func = func;
        }

        public Node ToNode()
        {
            return new OperationNode(Name, Func);
        }

        public override string ToString() => Name;

        public static List<OperationEnum> GetAll()
        {
            var fields = typeof(OperationEnum).GetFields(BindingFlags.Public |
                                                BindingFlags.Static |
                                                BindingFlags.DeclaredOnly);
  
            IEnumerable<object> val = fields.Select(f => f.GetValue(null));
            return val.Cast<OperationEnum>().ToList();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as OperationEnum;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Name.Equals(otherValue.Name);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Name.CompareTo(((OperationEnum)other).Name);
        
    }
}
