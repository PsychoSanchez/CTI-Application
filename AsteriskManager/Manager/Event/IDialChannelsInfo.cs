namespace AsteriskManager.Manager.Event
{
    public interface IDialChannelInfo
    {
        string CallerIDNum { get; set; }
        string CallerIDName { get; set; }
        string ConnectedLineName { get; set; }
        string ConnectedLineNum { get; set; }
    }
}
