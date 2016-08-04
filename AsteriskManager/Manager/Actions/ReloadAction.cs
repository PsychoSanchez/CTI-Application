namespace AsteriskManager.Manager.Actions
{
    class ReloadAction : ActionManager
    {
        public override string Action
        {
            get
            {
                return "Reload";
            }
        }
        public string Module { get; set; }
        public ReloadAction()
        {

        }
        public ReloadAction(string Module)
        {
            this.Module = Module;
        }
        public override string Parameters
        {
            get
            {
                if (!string.IsNullOrEmpty(Module))
                    return Module + Helper.LINE_SEPARATOR;
                return string.Empty;
            }
        }
    }
}
