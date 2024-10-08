﻿
namespace QuickFix.Logger;

/// <summary>
/// Log implementation that does not do anything
/// </summary>
public sealed class NullLog : ILog
{
    #region ILog Members

    public void Clear()
    { }

    public void OnIncoming(string msg)
    { }

    public void OnOutgoing(string msg)
    { }

    public void OnEvent(string s)
    { }

    public void Dispose()
    { }

    #endregion

    #region ILog Members FTS

    public void FTSLogTraceAppend(string s) { }
    public void FTSLogTraceAppendElapsedTicks() { }

    public void FTSLogTraceAppendElapsedTicksTotal() { }

    #endregion
}
