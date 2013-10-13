////
namespace UserInterface
{
    using System;
    using System.Linq;

    public interface IUserIntarface
    {
        void ProcessInput(string command);

        void ShowStartScreen();
    }
}
