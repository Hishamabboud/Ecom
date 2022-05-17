using Ecommerence.Domain.Events.Common;
using System;

namespace Ecommerence.Domain.Commands.Common
{
    public abstract class Command : Message
    {
        public DateTime DateTime { get; private set; }

        protected Command()
        {
            DateTime = DateTime.Now;
        }
    }
}
