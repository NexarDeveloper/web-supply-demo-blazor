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
            NexarMode == Mode.Prod ? "https://identity.nexar.com/" : "https://identity.nexar.com/";

        /// <summary>
        /// The Nexar GraphQL API endpoint.
        /// </summary>
        public string ApiEndpoint =>
            NexarMode == Mode.Prod ? "https://api.nexar.com/graphql" : "https://api.nexar.com/graphql";

        /// <summary>
        /// The Nexar home page.
        /// </summary>
        public string NexarDotCom =>
            NexarMode == Mode.Prod ? "http://nexar.com" : "http://nexar.com";

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
    }
}
