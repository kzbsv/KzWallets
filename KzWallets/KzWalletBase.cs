#region Copyright
// Copyright (c) 2019 TonesNotes
// Distributed under the Open BSV software license, see the accompanying file LICENSE.
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace KzWallets.Wallet
{
    /// <summary>
    /// Base class for KzWallets.
    ///
    /// Implements basic HD wallet operations based on an assigned KzExtPrivKey (not a master key).
    /// Keeps track 
    /// Support for persisting state.
    /// Support for protecting secrets in memory.
    /// Support for interwallet communication.
    /// </summary>
    public abstract class KzWalletBase
    {
    }
}
