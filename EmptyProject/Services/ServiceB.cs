namespace EmptyProject.Services
{
    public class ServiceB : IServiceB
    {

        private readonly IServiceA _serviceA;

        public ServiceB(IServiceA serviceA)
        {
            _serviceA = serviceA;
        }


        public string GetMsg()
        {
            return


               $"{_serviceA.GetMsg()} + Msg from  Service B";

        }
    }
}
