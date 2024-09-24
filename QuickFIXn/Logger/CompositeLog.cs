#nullable enable
using System;

namespace QuickFix.Logger;

/// <summary>
/// File log implementation
/// </summary>
internal class CompositeLog : ILog
{
    private readonly ILog[] _logs;

    private bool _disposed = false;

    public CompositeLog(ILog[] logs)
    {
        _logs = logs;
    }

    public void Clear()
    {
        DisposedCheck();
        foreach (var log in _logs)
            log.Clear();
    }

    public void OnIncoming(string msg)
    {
        DisposedCheck();
        foreach (var log in _logs)
            log.OnIncoming(msg);
    }

    public void OnOutgoing(string msg)
    {
        DisposedCheck();
        foreach (var log in _logs)
            log.OnOutgoing(msg);
    }

    public void OnEvent(string s)
    {
        DisposedCheck();
        foreach (var log in _logs)
            log.OnEvent(s);
    }

    #region ILog Members FTS

    public void FTSLogTraceAppend(string s) { }
    public void FTSLogTraceAppendElapsedTicks() { }

    public void FTSLogTraceAppendElapsedTicksTotal() { }

    #endregion

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            foreach (var log in _logs)
                log.Dispose();
        }
        _disposed = true;
    }

    private void DisposedCheck()
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().Name);
    }

    ~CompositeLog() => Dispose(false);
}
