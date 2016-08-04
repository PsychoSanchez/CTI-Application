namespace AsteriskManager.Manager.Actions
{
    /// <summary>
    /// Абстрактный класс для хранения информации о дейсвии, его ID и ключе прокси
    /// От него наследуются все классы и методы Action действий
    /// </summary>
    public abstract class ActionManager
    {
        private string _actionID;
        private string _ProxyKey;

        public abstract string Action { get; }
        public abstract string Parameters { get; }

        public string ActionID
        {
            get { return this._actionID; }
            set { this._actionID = value; }
        }

        public virtual string ProxyKey
        {
            get { return this._ProxyKey; }
            set { this._ProxyKey = value; }
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
