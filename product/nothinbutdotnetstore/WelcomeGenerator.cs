namespace nothinbutdotnetstore
{
    public class WelcomeGenerator
    {
        public string get_welcome_message_for(string name)
        {
            return string.Format("Hello {0}", name);
        }
    }
}