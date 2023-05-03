using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace DeveloperSample.Syncing
{
    public class SyncTest
    {
        [Fact]
        public void CanInitializeCollection()
        {
            var debug = new SyncDebug();
            var items = new List<string> { "one", "two" };
            var result = debug.InitializeList(items);
            Assert.Equal(items.Count, result.Count);
        }

        [Fact(Skip="Not implemented")]
        public void ItemsOnlyInitializeOnce()
        {
            var debug = new SyncDebug();
            var count = 0;
            var dictionary = debug.InitializeDictionary((i, threadIndex) =>
            {
                Thread.Sleep(1);
                Interlocked.Increment(ref count);
                return i.ToString() + "-" + threadIndex;
            });

            Assert.Equal(100, count);
            Assert.Equal(100, dictionary.Count);
        }
    }
}