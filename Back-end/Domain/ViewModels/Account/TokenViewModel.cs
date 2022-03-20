namespace Domain.ViewModels.Account
{
    public class TokenViewModel
    {
        public TokenViewModel()
        {
            Access_token = string.Empty;
            Refresh_token = string.Empty;
            Expires_in = 0;
        }

        public TokenViewModel(string access_token, string refresh_token, long expires_in)
        {
            Access_token = access_token;
            Refresh_token = refresh_token;
            Expires_in = expires_in;
        }

        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
        public long Expires_in { get; set; }
    }
}
