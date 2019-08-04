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
    /// A Bitcoin wallet for managing identities.
    /// Manages addresses which serve as identifies: People, Protocols, etc.
    /// Manages endorsements of those identities: Real world attributes (e-mail, passport, ss#, street address), 3rd party accounts (twitter, reddit, SM...)
    /// Supports sharing endorsements without revealing what else has received the endorsement.
    /// Supports shared ownership of identities using threshold signature protocols.
    /// Uses HD/bip32 keys.
    /// </summary>
    public class KzWalletIdentity : IKzWallet
    {
        KzPubKey _KzIdentityProtocol;

        List<KzPubKey> _KnownIdentities = new List<KzPubKey>();
        List<KzPrivKey> _OwnedIdentities = new List<KzPrivKey>();
    }
}
