namespace AsteriskManager.Manager.Actions
{
    class LogoffAction : ActionManager
    {
        /// <summary>
        /// Возвращает название действия
        /// </summary>
        public override string Action
        {
            get
            {
                return "Logoff";
            }
        }

        public override string Parameters
        {
            get
            {
                return "";
            }
        }
    }
}
