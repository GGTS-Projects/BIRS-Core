using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Classes.IO
{
    public partial class Persistence
    {
        public sealed class GetBlocks
        {
        }

        public sealed class GetTransactions
        {
        }

        public sealed class GetUnconfirmedTransactions
        {
        }

        public sealed class GetTransaction
        {
            public GetTransaction(string id)
            {
                Id = id;
            }

            public string Id;
        }
    }
}
