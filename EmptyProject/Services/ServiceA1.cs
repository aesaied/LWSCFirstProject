namespace EmptyProject.Services
{
    public class ServiceA1 : IServiceA
    {
        private DateTime _creationTime;
        public ServiceA1()
        {
            _creationTime= DateTime.Now;
        }
        public string GetMsg()
        {
            return $@"Welcome from  Service A1
                  {_creationTime.ToString()}";
        }
    }
}
