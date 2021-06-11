using System;

namespace Nexar.Supply.Services
{
    public class AppData
    {
        public Mode NexarMode { get; set; } = Mode.Prod;

        public string Authority =>
            NexarMode == Mode.Prod ? "https://identity.nexar.com/" : "https://identity.nexar.com/";

        public string ApiEndpoint =>
            NexarMode == Mode.Prod ? "https://api.nexar.com/graphql" : "https://api.nexar.com/graphql";

        public string NexarDotCom =>
            NexarMode == Mode.Prod ? "http://nexar.com" : "http://nexar.com";

        public string Token
        {
            get => token;
            set
            {
                token = value;
                OnChange?.Invoke();
            }
        }
        public event Action OnChange;
        private string token;
    }

    public enum Mode
    {
        Prod,
        Dev,
    }
}
