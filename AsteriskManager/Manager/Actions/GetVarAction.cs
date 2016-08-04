namespace AsteriskManager.Manager.Actions
{
    class GetVarAction : ActionManager
    {
        /// <summary>
        /// Пустой конструктор по умолчанию
        /// </summary>
        public GetVarAction()
        {

        }
        /// <summary>
        /// Конаструктор для передачи серверу глобальной переменной
        /// </summary>
        /// <param name="variable"></param>
        public GetVarAction(string variable)
        {
            Variable = variable;
        }
        /// <summary>
        /// Конструктор для передачи серверу переменной в локальном канале
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="channel"></param>
        public GetVarAction(string variable, string channel)
        {
            Variable = variable;
            Channel = channel;
        }
        public string Variable { get; set; }
        public string Channel { get; set; }
        public override string Action
        {
            get
            {
                return "GetVar";
            }
        }

        public override string Parameters
        {
            get
            {
                string Parameters;
                if (!string.IsNullOrEmpty(Variable))
                {
                    Parameters = "Variable: " + Variable + Helper.LINE_SEPARATOR;
                    if (!string.IsNullOrEmpty(Channel))
                    {
                        return string.Concat(Parameters, "Channel: ", Channel, Helper.LINE_SEPARATOR);
                    }
                    return Parameters;
                }
                return null;
            }
        }
    }
}
