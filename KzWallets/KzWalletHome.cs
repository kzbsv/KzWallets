#region Copyright
// Copyright (c) 2019 TonesNotes
// Distributed under the Open BSV software license, see the accompanying file LICENSE.
#endregion
using KzBsv;
using System;
using System.Collections.Generic;
using System.Text;

namespace KzWallets
{
    /// <summary>
    /// A Bitcoin wallet for managing household money: A few months of cashflow.
    /// Enough value that a password is needed to spend from the open wallet.
    /// Uses HD/bip32 keys.
    /// </summary>
    public class KzWalletHome : IKzWallet
    {
        KzB58ExtPrivKey _b58ExtPrivKey = new KzB58ExtPrivKey();
    }
}
