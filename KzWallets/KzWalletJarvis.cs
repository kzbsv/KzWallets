#region Copyright
// Copyright (c) 2019 TonesNotes
// Distributed under the Open BSV software license, see the accompanying file LICENSE.
#endregion
using KzBsv;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KzWallets
{
    /// <summary>
    /// Manages a collection of wallets.
    /// Supports automatic transfers between wallets to maintain minimum balances.
    /// Manages a wallet with minimal balance, HD keys, for protocol transactions (non-data-intesive).
    /// Manages master HD keys for wallets that don't keep their own.
    /// </summary>
    public class KzWalletJarvis : IDisposable
    {
        static KzKeyPath _kp_magic = "m/623'/0'/0";
        static KzKeyPath _kp_protocol = "m/623'/1'/0";

        /// <summary>
        /// This wallets identity.
        /// Keys generated from this master are used to encrypt
        /// and identify actions taken and data stored by this
        /// wallet manager.
        /// m/623'/0'/0 is my magic value. e.g. =>pub=>Hash160 used to identify stuff belonging to me.
        /// m/623'/1'/0 is my primary protocol key used to sign and encrypt.
        /// When generating a new master, each of these derivations must be tested and be valid.
        /// If any of them fail, the seed is "incremented" until they succeed.
        /// </summary>
        KzExtPrivKey _me;

        KzUInt160 _magic;

        /// <summary>
        /// </summary>
        KzExtPrivKey _protocolKey;

        /// <summary>
        /// Anchors all the state known and managed by this instance.
        /// </summary>
        KzOutPoint _anchor;

        List<IKzWallet> _wallets = new List<IKzWallet>();

        List<KzExtPrivKey> _masterKeys = new List<KzExtPrivKey>();

        public string FundingAddress => _magic.ToPubKeyAddress();

        public List<KzB58ExtPrivKey> MasterKeys => _masterKeys.Select(m => new KzB58ExtPrivKey(m)).ToList();

        bool _signalCleanup;
        Task _task;

        public KzWalletJarvis() { }

        public KzWalletJarvis(string passPhrase)
        {
            var m = KzExtPrivKey.Master(passPhrase, new[] { _kp_magic, _kp_protocol });
            if (m == null)
                throw new ArgumentException("This pass phrase cannot be used. Please generate another with at least 256 bits of entropy.");

            _magic = m.Derive(_kp_magic).GetPubKey().ToHash160();
            _protocolKey = m.Derive(_kp_protocol.Parent);

            _task = Task.Run(async () => await JarvisMain());
        }

        void CleanupTasks()
        {
            //_signalCleanup = true;
            _task.Wait();
        }

        class WocByAddressUnspent
        {
            public int height;
            public int tx_pos;
            public string tx_hash;
            public long value;
        }

        async Task JarvisMain()
        {
            var woc = new KzApiWhatsOnChain();

            var unspent = (List<KzApiWhatsOnChain.ByAddressUnspent>)null;

            while (!_signalCleanup) {
                // Wait for funding...
                unspent = await woc.GetUnspentTransactionsByAddress(FundingAddress);
                if (unspent.Count > 0)
                    break;
                Console.WriteLine($"Please fund{FundingAddress} with a few mBSV...");
                await Task.Delay(TimeSpan.FromSeconds(10));
            }

            Debug.Assert(unspent.Count == 1);
            
            var txid = unspent[0].tx_hash.ToKzUInt256();
            var tx = await woc.GetTransactionsByHash(txid);

            Debug.Assert(tx != null);

            // Let's see if we have data to decode:
            var txb = new KzBTransaction(tx);
            var ors = txb.FindPushDataByProtocol(_magic).ToArray();

            Debug.Assert(ors.Length < 2);

            if (ors.Length == 1) {
                // Recover wallet state from transaction output data.
            }
        }

        public void Dispose()
        {
            CleanupTasks();
        }
    }
}
