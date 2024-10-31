using Supabase.Postgrest;
using System.Threading.Tasks;

namespace TechChallenge.Infra.Data
{
    public class SupabaseConnection
    {
        private readonly Supabase.Client _client;

        public SupabaseConnection(string url, string apiKey)
        {
            _client = new Supabase.Client(url, apiKey);
        }

        public Supabase.Client GetClient()
        {
            return _client;
        }
    }
}