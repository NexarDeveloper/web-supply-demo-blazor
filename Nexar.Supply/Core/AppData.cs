using System;

namespace Nexar.Supply
{
    /// <summary>
    /// The application state and options. Different modes and URLs are only
    /// needed for internal development. Clients normally use nexar.com URLs.
    /// </summary>
    public class AppData
    {
        public Mode NexarMode { get; set; } = Mode.Prod;

        /// <summary>
        /// The identity server endpoint.
        /// </summary>
        public string Authority =>
            NexarMode switch
            {
                Mode.Prod => "https://identity.nexar.com/",
                Mode.Dev => "https://identity.nexar.com/",
                _ => "https://identity.nexar.com/",
            };

        /// <summary>
        /// The Nexar GraphQL API endpoint.
        /// </summary>
        public string ApiEndpoint =>
            NexarMode switch
            {
                Mode.Prod => "https://api.nexar.com/graphql",
                Mode.Dev => "https://api.nexar.com/graphql",
                _ => "https://api.nexar.com/graphql",
            };


        /// <summary>
        /// The Nexar home page.
        /// </summary>
        public string NexarDotCom =>
            NexarMode switch
            {
                Mode.Prod => "https://nexar.com",
                Mode.Dev => "http://nexar.com",
                _ => "http://nexar.com",
            };

        /// <summary>
        /// The current session token.
        /// </summary>
        public string Token
        {
            get => token;
            set
            {
                token = value;
                OnChange?.Invoke();
            }
        }
        private string token;

        /// <summary>
        /// This event is triggered on changes.
        /// </summary>
        public event Action OnChange;
    }

    public enum Mode
    {
        Prod,
        Dev,
        Uat
    }
}
