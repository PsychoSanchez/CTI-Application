namespace AsteriskManager.Manager.Actions
{
    class StatusAction : ActionManager
    {
        public string Channel { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public StatusAction()
        {
        }
        /// <summary>
        /// Создает Hangup Action с названием канала, который нужно закрыть
        /// </summary>
        /// <param name="channel"></param>
        public StatusAction(string channel)
        {
            Channel = channel;
        }
        public override string Action
        {
            get
            {
                return "Status";
            }
        }

        public override string Parameters
        {
            get
            {
                if (!string.IsNullOrEmpty(Channel))
                    return string.Concat("Channel: ", Channel, Helper.LINE_SEPARATOR);
                return null;
            }
        }
    }
}
