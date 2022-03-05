using System.Collections.Generic;

namespace SSJ.Enquete.WebApp.Classes
{
    public class Sequence
    {
        private readonly Dictionary<string, int> _sequences = new Dictionary<string, int>();

        public int NextValueFor(string sequenceName)
        {
            _sequences.TryGetValue(sequenceName, out var value);
            return _sequences[sequenceName] = value + 1;
        }
    }
}
