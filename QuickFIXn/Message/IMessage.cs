﻿using System;

namespace QuickFix {

    /// <summary>
    /// Represents a FIX message interface
    /// </summary>
    public interface IMessage {
        public string MsgType { get; }
        public short  MsgMaxBufferLength { get; }

        public SeqNumType MsgSeqNum { get; set; }

        public ReadOnlySpan<byte> GetSpan();
    }
}
