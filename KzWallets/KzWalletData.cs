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
    /// A Bitcoin wallet for managing data persisted to the blockchain/metanet.
    /// Manages a sub-wallet of low value, high number of UTXOs for generating transactions
    /// that move MB/GB onto the blockchain.
    /// Manages synchronization and access to owned content.
    /// Supports multiple storage/retrieval protocols.
    /// Uses HD/bip32 keys.
    /// </summary>
    public class KzWalletData : IKzWallet
    {
        KzB58ExtPrivKey _b58ExtPrivKey = new KzB58ExtPrivKey();
    }
}
