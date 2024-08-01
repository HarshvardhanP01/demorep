namespace Facade
{
    public class DvdPlayer
    {
        public void On() => Console.WriteLine("DVD Player is on.");
        public void Play(string? movie) => Console.WriteLine($"Playing Movie:{movie}");
        public void Stop() => Console.WriteLine("Stopping Movie.");
        public void Off() => Console.WriteLine("DVD Player is off.");
    }

    public class Projector
    {
        public void On() => Console.WriteLine("Projector is on.");
        public void Off() => Console.WriteLine("Projector is off.");
        public void WideScreenMode() => Console.WriteLine("Projector is in Wide Screen Mode.");
    }

    public class Lights
    {
        public void On() => Console.WriteLine("Lights is on.");
        public void Off() => Console.WriteLine("Lights is off.");
        public void Dim(int level) => Console.WriteLine($"Light is Dim as : {level}");
    }

    public class SoundSystem
    {
        public void On() => Console.WriteLine("Sound System is on.");
        public void Off() => Console.WriteLine("Sound System is off.");
        public void SetVolume(int level) => Console.WriteLine($"Sound is at: {level}");

    }

    public class HomeTheaterFacade
    {
        private DvdPlayer player;
        private Projector projector;
        private Lights light;
        private SoundSystem soundSystem;

        public HomeTheaterFacade(DvdPlayer player, Projector projector, Lights light, SoundSystem soundSystem)
        {
            this.player = player;
            this.projector = projector;
            this.light = light;
            this.soundSystem = soundSystem;
        }

        public void WatchMovie(string? moviename)
        {
            Console.WriteLine("Get Ready to watch a Movie...");
            light.On();
            light.Dim(1);
            projector.On();
            projector.WideScreenMode();
            soundSystem.On();
            soundSystem.SetVolume(3);
            player.On();
            player.Play(moviename);
        }

        public void EndMovie()
        {
            Console.WriteLine("Ending Movie.");
            light.Off();
            projector.Off();
            soundSystem.Off();
            player.Stop();
            player.Off();
            light.On();
            light.Dim(10);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DvdPlayer player = new DvdPlayer();
            Projector projector = new Projector();
            SoundSystem soundSystem = new SoundSystem();
            Lights light = new Lights();

            HomeTheaterFacade homeTheaterFacade=new HomeTheaterFacade(player,projector,light,soundSystem);
            homeTheaterFacade.WatchMovie("Jab We Met");
            homeTheaterFacade.EndMovie();
        }
    }
}
