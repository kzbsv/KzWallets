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
    /// A Bitcoin wallet for managing walking-around money: A few days/weeks of cashflow.
    /// Not so much value that a password is needed to spend from the open wallet.
    /// Uses HD/bip32 keys.
    /// </summary>
    public class KzWalletPocket : IKzWallet
    {
        KzB58ExtPrivKey _b58ExtPrivKey = new KzB58ExtPrivKey();
    }
}
