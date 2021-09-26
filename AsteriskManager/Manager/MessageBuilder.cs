
using System.Collections.Generic;
using System.Text;
using AsteriskManager.Parser;

namespace AsteriskManager
{
    [System.Serializable]
    public class AmiMessageBuildingFinishedException : System.Exception
    {
        public AmiMessageBuildingFinishedException() { }
    }

    internal interface IAmiMessageBuildingStrategy
    {
        IAmiMessageBuildingStrategy Add<T>(string key, T value);
        string Build();
    }

    internal class FinishedAmiMessageBuildingStrategy : IAmiMessageBuildingStrategy
    {
        public IAmiMessageBuildingStrategy Add<T>(string key, T value)
        {
            throw new AmiMessageBuildingFinishedException();
        }

        public string Build()
        {
            throw new AmiMessageBuildingFinishedException();
        }
    }

    internal class ActiveAmiMessageBuildingStrategy : IAmiMessageBuildingStrategy
    {
        private StringBuilder sb = new StringBuilder();

        public IAmiMessageBuildingStrategy Add<T>(string key, T value)
        {
            sb.Append(key);
            sb.Append(AMIParser.KEY_VALUE_SEPARATOR);
            sb.Append(value);
            sb.Append(AMIParser.LINE_SEPARATOR);

            return this;
        }

        public override string ToString()
        {
            return sb.ToString();
        }

        public string Build()
        {
            sb.Append(AMIParser.LINE_SEPARATOR);
            return sb.ToString();
        }
    }

    class AmiMesasgeBuilder
    {
        private IAmiMessageBuildingStrategy strategy = new ActiveAmiMessageBuildingStrategy();

        public AmiMesasgeBuilder Add<T>(string key, T value)
        {
            strategy.Add(key, value);

            return this;
        }

        public AmiMesasgeBuilder AddFields(Dictionary<string, object> fields)
        {
            foreach (var item in fields)
            {
                strategy.Add(item.Key, item.Value);
            }

            return this;
        }

        public override string ToString()
        {
            // TODO: Replace all work with helper build action to this class
            // sb.Append(AMIParser.LINE_SEPARATOR);
            return strategy.ToString();
        }

        public string Build()
        {
            var result = strategy.Build();

            strategy = new FinishedAmiMessageBuildingStrategy();

            return result;
        }
    }
}