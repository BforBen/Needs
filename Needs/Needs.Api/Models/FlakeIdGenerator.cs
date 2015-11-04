using System;
using FlakeGen;

namespace Needs.Api.Models
{
    internal sealed class IdGen
    {
        private static volatile Id64Generator FlakeGen;
        private static object syncRoot = new Object();

        private IdGen() { }

        internal static Id64Generator Instance
        {
            get
            {
                if (FlakeGen == null)
                {
                    lock (syncRoot)
                    {
                        if (FlakeGen == null)
                        {
                            FlakeGen = new Id64Generator();
                        }
                    }
                }

                return FlakeGen;
            }
        }
    }
    public class FlakeIdGenerator : MongoDB.Bson.Serialization.IIdGenerator
    {
        public object GenerateId(object container, object document)
        {
            return IdGen.Instance.GenerateId();
        }

        public bool IsEmpty(object id)
        {
            return id == null || String.IsNullOrWhiteSpace(id.ToString());
        }
    }
}