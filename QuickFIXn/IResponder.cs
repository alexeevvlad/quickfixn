﻿using System;

namespace QuickFix
{
    /// <summary>
    /// Used by a Session to send raw FIX message data and to disconnect a
    /// connection. This interface is used by Acceptor or Initiator implementations.
    /// </summary>
    public interface IResponder
    {
        /// <summary>
        /// Sends a raw FIX message
        /// </summary>
        /// <param name="s">the raw FIX message data</param>
        /// <returns>true if successful, false if send operation failed</returns>
        bool Send(string s);

        /// <summary>
        /// Sends a raw FIX message
        /// </summary>
        /// <param name="rawData">the raw FIX message byte[]</param>
        /// <returns>true if successful, false if send operation failed</returns>
        bool Send(ReadOnlySpan<byte> rawData);

        /// <summary>
        /// Disconnect the underlying connection
        /// </summary>
        void Disconnect();
    }
}
