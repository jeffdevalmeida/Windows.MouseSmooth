using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Faculdade.MouseSmooth
{
    internal class Program
    {
        const uint SPI_SET_SPEED = 0x0071;
        const uint SPI_SETMOUSECLICKLOCK = 0x101F;
        const uint SPI_SETMOUSECLICKLOCKTIME = 0x2009;
        const uint SPI_SETSNAPTODEFBUTTON = 0x0060;
        const uint SPI_SETMOUSETRAILS = 0x005D;

        const uint MOUSE_SMOOTH_SPEED = 3;
        const uint MOUSE_DEFAULT_SPEED = 10;
        const bool MOUSE_CLICKLOCK = true;
        const uint MOUSE_CLICKLOCKTIME = 2;
        const bool MOUSE_SNAPTO = true;
        const bool MOUSE_POINTERTRAIL = true;

        [DllImport("user32.dll")]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

        static void Main(string[] args)
        {
            SetSmoothSpeed(MOUSE_SMOOTH_SPEED);
            SetClickLock(MOUSE_CLICKLOCK, MOUSE_CLICKLOCKTIME);
            SetSnapToPointer(MOUSE_SNAPTO);
            SetTrailPointer(MOUSE_POINTERTRAIL);

            Console.ReadKey();
            SetDefaultSpeed();
        }

        static void SetSmoothSpeed(uint speed) => SystemParametersInfo(SPI_SET_SPEED, 0, speed, 0);
        static void SetDefaultSpeed() => SystemParametersInfo(SPI_SET_SPEED, 0, MOUSE_DEFAULT_SPEED, 0);
        static void SetSnapToPointer(bool use) => SystemParametersInfo(SPI_SETSNAPTODEFBUTTON, 0, use ? 1 : (uint)0, 0);
        static void SetTrailPointer(bool use) => SystemParametersInfo(SPI_SETMOUSETRAILS, 0, use ? 1 : (uint)0, 0);
        static void SetClickLock(bool use, uint time)
        {
            SystemParametersInfo(SPI_SETMOUSECLICKLOCK, 0, use ? 1 : (uint)0, 0);
            SystemParametersInfo(SPI_SETMOUSECLICKLOCKTIME, 0, time, 0);
        }

        //TODO: Adicionar precisão de ponteiro

        //TODO: Adicionar ajuste do tamanho do mouse
    }
}
