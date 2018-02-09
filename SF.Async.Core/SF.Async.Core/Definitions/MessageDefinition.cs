using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core.Definitions
{
    public class MessageDefinition: IData
    {
        public MessageStatus MessageStatus { get; set; }

        public IAsyncAction OriginalAsyncAction { get; set; }

        public IAsyncAction DestinationAsyncAction { get; set; }

        public IContentBox ContentBox { get; set; }

        public Stack<IContentBox> ContentBoxStack { get; set; }

        public Stack<Stack<IAsyncAction>> AsyncActionStack { get; set; }

        public string UniqueID => Guid.NewGuid().ToString();
    }
}
