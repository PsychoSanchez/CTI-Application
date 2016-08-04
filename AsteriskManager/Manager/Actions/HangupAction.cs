namespace AsteriskManager.Manager.Actions
{
    class HangupAction : ActionManager
    {
        public string Channel { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public HangupAction()
        {
        }
        /// <summary>
        /// Создает Hangup Action с названием канала, который нужно закрыть
        /// </summary>
        /// <param name="channel"></param>
        public HangupAction(string channel)
        {
            Channel = channel;
        }
        public override string Action
        {
            get
            {
                return "Hangup";
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
