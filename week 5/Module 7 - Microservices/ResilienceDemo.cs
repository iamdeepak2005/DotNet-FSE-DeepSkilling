using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Training.Week5.Resilience
{
    // mock Polly simulator policy to prevent external dependency compilation errors
    public class PollyCircuitBreakerPolicy
    {
        private int _failedAttempts = 0;
        private bool _isOpen = false;

        public async Task<string> ExecuteAsync(Func<Task<string>> action)
        {
            if (_isOpen)
            {
                throw new InvalidOperationException("Circuit Breaker is OPEN. Request blocked.");
            }

            try
            {
                string result = await action();
                _failedAttempts = 0; // reset
                return result;
            }
            catch (Exception ex)
            {
                _failedAttempts++;
                if (_failedAttempts >= 3)
                {
                    _isOpen = true;
                    Console.WriteLine("[Polly Policy] Threshold reached! Circuit breaker transitions to OPEN.");
                }
                throw;
            }
        }
    }

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- resilience circuit breaker test ---");

            var policy = new PollyCircuitBreakerPolicy();
            int callId = 1;

            Func<Task<string>> mockExternalApiCall = () =>
            {
                Console.WriteLine($"Executing api call #{callId++}...");
                // simulate downstream outage
                throw new HttpRequestException("Service down.");
            };

            // execute calls using policy wrapper
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    await policy.ExecuteAsync(mockExternalApiCall);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Call failed: {ex.Message}");
                }
            }
        }
    }
}