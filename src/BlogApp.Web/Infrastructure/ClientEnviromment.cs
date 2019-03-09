namespace BlogApp.Web.Infrastructure
{
    public class ClientEnviromment : IClientEnviromment
    {
        public bool IsDevelopment
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }

    public interface IClientEnviromment
    {
        bool IsDevelopment { get; }
    }
}