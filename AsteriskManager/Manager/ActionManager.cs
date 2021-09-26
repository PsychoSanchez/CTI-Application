using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    public interface ISerializableAmiAction
    {
        string GetActionId();
        string GetActionName();
        Dictionary<string, object> GetFields();
    }

    /// <summary>
    /// Абстрактный класс для хранения информации о дейсвии, его ID и ключе прокси
    /// От него наследуются все классы и методы Action действий
    /// </summary>
    public abstract class BaseAmiAction : ISerializableAmiAction
    {
        private readonly string actionId;
        private readonly string action;
        public BaseAmiAction(string actionId, string action)
        {
            this.actionId = actionId;
            this.action = actionId;
        }

        public BaseAmiAction(string action)
        {
            this.actionId = Helper.MachineID;
            this.action = actionId;
        }

        public virtual string GetActionId() => actionId;
        public virtual string GetActionName() => action;

        public abstract Dictionary<string, object> GetFields();
    }
}
