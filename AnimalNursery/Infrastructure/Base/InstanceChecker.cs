using System.Threading;

namespace AnimalNursery.Infrastructure.Base
{
    internal class InstanceChecker
    {
        static readonly Mutex mutex = new(false, "AnimalNursery");
        public static bool TakeMemory()
        {
            return mutex.WaitOne();
        }
    }
}
