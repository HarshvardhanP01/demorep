using DemoFirst.BizLayer.Contracts;

namespace DemoFirst.BizLayer.Services
{
    public class MyClassV1 : IMyService
    {
        public string GetData(string userName)
        {
            return $"Hello,{userName}";
        }
    }
}
