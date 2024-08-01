using DemoFirst.BizLayer.Contracts;

namespace DemoFirst.BizLayer.Services
{
    public class MyClassV2 : IMyService
    {
        public string GetData(string userName)
        {
            return $"Hi,{userName}";
        }
    }
}
