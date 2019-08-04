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
    /// A Bitcoin wallet for managing personal wealth money: Long term storage.
    /// Support retirement/big puchase occasional spending.
    /// Supports long term saving with frequent deposits.
    /// A password and 2FA is needed to spend from an open wallet.
    /// Uses HD/bip32 keys for deposits.
    /// Prefers manually generated (e.g. die rolling, custom-procedural) entropy for primary private keys.
    /// </summary>
    public class KzWalletCold : IKzWallet
    {
        List<KzPrivKey> _keys = new List<KzPrivKey>();
    }
}
