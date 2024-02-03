using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal class CommandHacker : ICommand
    {
        public string Name => "hacker";

        public string HelpText => "hacker-[Any valid number] -> Makes you a Master haxxor, for as long as specified.";

        public void Execute(string Parameter)
        {
            try
            {
                string pattern1 = @"
aAbBcCdD   eEfFgGhHiIjJ   kKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ          MnNoOpPqQrRsStTuUvVwWxXyYzZ     RSTUVWXYZ   abcdefghijklmnopqrs
1!2@3#4$   5%6^7&8*9(0)   -_=+[{]}|\;:',<.>?/RSTU               VWXYZ   abcdefghijklmnopqrsRSTUVWXYZ      abcdefghijklmnopqrs
a1b2c3d4   e5f6g7h8i9j0   k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z63n4           o5p6q7r8s9t0u1v2w3x4y  5z6m3n4o5p6q7r8s9t  m3n4o5p6q7r8s9tm3n4o5p6q7r8s9t
A7B8C9D0   E1F2G3H4I5J6   K7L8M9N0O1P2Q3R4S5T6U7V8W9X0          I5J6   K7L8M9N0O1P2Q3R4S5T6U7V8W
!@#$%^&*   ()_-+=[]{}|;:,.<>?/   `~
123456789   0ABCDEFGHIJKLMNOPQRSTUVWXYZ   abcdefghijklmnopqrstuvwxyz         abcdefghijklmnopqrstuvwxyz
JKLMNOPQR   STUVWXYZ   ~`!@#$%^&*()-_=+$%^&*            ()-_=ijklmnopqrstuvwxyz         abcdefghijklmnopqr^&*()-_=+ 
a1b2c3d4   e5f6g7h8i9j0   k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z6                  a1b2c3d4   e5f6g7h8i9j0   k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z6   
A7B8C9D0   E1F2G3H4I5J6   K7L8M9N0O1P2Q3R4S5T6U7V8W9X0                      A7B8C9D0   E1F2G3H4I5J6   K7L8M9N0O1P2Q3R4S5T6U7V8W9X0
!@#$%^&*   ()_-+=[]{}|;:,.<>?/   `~             !@#$%^&*   ()_-+=[]{}|;:,.<>?/   `~
123456789   0ABCDEFGHIJKLMNOPQRSTUVWXYZ   abcdefghijklmnopqrstuvwxyz            JKLMNOPQRSTUVWXYZ   abcdefghijklmnopqrstuvwxyz
JKLMNOPQR   STUVWXYZ   ~`!@#$%^&*()-_=+
aAbBcCdD   eEfFgGhHiIjJ   kKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ          MnNoOpPqQrRsStTuUvVwWxXyYzZ     RSTUVWXYZ   abcdefghijklmnopqrs
1!2@3#4$   5%6^7&8*9(0)   -_=+[{]}|\;:',<.>?/RSTU               VWXYZ   abcdefghijklmnopqrsRSTUVWXYZ      abcdefghijklmnopqrs";

                string pattern2 = @"
a1b2c3d4   e5f6g7h8i9j0   k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z6                  a1b2c3d4   e5f6g7h8i9j0   k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z6   
A7B8C9D0   E1F2G3H4I5J6   K7L8M9N0O1P2Q3R4S5T6U7V8W9X0                      A7B8C9D0   E1F2G3H4I5J6   K7L8M9N0O1P2Q3R4S5T6U7V8W9X0
!@#$%^&*   ()_-+=[]{}|;:,.<>?/   `~             !@#$%^&*   ()_-+=[]{}|;:,.<>?/   `~
123456789   0ABCDEFGHIJKLMNOPQRSTUVWXYZ   abcdefghijklmnopqrstuvwxyz            JKLMNOPQRSTUVWXYZ   abcdefghijklmnopqrstuvwxyz
JKLMNOPQR   STUVWXYZ   ~`!@#$%^&*()-_=+
aAbBcCdD   eEfFgGhHiIjJ   kKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ          MnNoOpPqQrRsStTuUvVwWxXyYzZ     RSTUVWXYZ   abcdefghijklmnopqrs
1!2@3#4$   5%6^7&8*9(0)   -_=+[{]}|\;:',<.>?/RSTU               VWXYZ   abcdefghijklmnopqrsRSTUVWXYZ      abcdefghijklmnopqrs
a1b2c3d4   e5f6g7h8i9j0   k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z63n4           o5p6q7r8s9t0u1v2w3x4y  5z6m3n4o5p6q7r8s9t  m3n4o5p6q7r8s9tm3n4o5p6q7r8s9t
A7B8C9D0   E1F2G3H4I5J6   K7L8M9N0O1P2Q3R4S5T6U7V8W9X0          I5J6   K7L8M9N0O1P2Q3R4S5T6U7V8W
!@#$%^&*   ()_-+=[]{}|;:,.<>?/   `~
123456789   0ABCDEFGHIJKLMNOPQRSTUVWXYZ   abcdefghijklmnopqrstuvwxyz         abcdefghijklmnopqrstuvwxyz
JKLMNOPQR   STUVWXYZ   ~`!@#$%^&*()-_=+$%^&*            ()-_=ijklmnopqrstuvwxyz         abcdefghijklmnopqr^&*()-_=+            ";

                for (int i = 0; i < Parameter.Length * 250; i++)
                {
                    ConsoleColor currentColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(pattern1);
                    Console.WriteLine(pattern2);
                    Thread.Sleep(10);
                    Console.ForegroundColor = currentColor;
                }
            }
            catch 
            {
                throw new Exception("Hacker-Error: An error occured while trying to hack the Mainframe-Firewall-Kernel-Code");
            }
        }
    }
}
