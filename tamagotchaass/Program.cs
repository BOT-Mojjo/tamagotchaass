using System;
using System.Threading;
int tc = 0;
int cd = 0;
int clearcd = 0;
tama tamaga = new tama();
(int Left, int Top) cursor = Console.GetCursorPosition();

Console.WriteLine("Give your creature a name!");
tamaga.GiveName();
Console.Clear();
Console.WriteLine("press 'p' to play, and 'f' to feed");
if(Console.ReadKey().KeyChar == 'x') tamaga.debug.onOff = true;
Console.Clear();
Console.CursorVisible = false;
while(true){
    if(Console.KeyAvailable && cd == 0){
        cd = 20;
        clearcd = 0;
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch(key.KeyChar){
            case 'f':
                tamaga.Feed();
                break;
            case 'p':
                tamaga.Play();
                break;
            default:
            break;
        }
        if(tamaga.debug.onOff == true){
            Console.WriteLine(key.Key + "           ");
        }
    }
    if(tc == 20){
        tc = 0;
        // Console.Clear();
        tamaga.update();
        tamaga.PrntSts(cursor);
        cursor = (0,0);// Console.GetCursorPosition();
        if(clearcd == 200){
            (int, int) cursorCahce = Console.GetCursorPosition();
            Console.SetCursorPosition(0,5);
            Console.Write("                      ");
            Console.WriteLine();
            for(int i = 0; i < Console.WindowWidth; i++) Console.Write(" ");
            Console.SetCursorPosition(cursorCahce.Item1, cursorCahce.Item2);
        }
    }else {
        tc++;
        Thread.Sleep(5);
        if(cd > 0) cd--;
        if(clearcd < 200) clearcd++;
    }
    if(tamaga.debug.onOff == true){
        Console.SetCursorPosition(cursor.Left, cursor.Top+2);
        if(tc.ToString().Length == 1){
            Console.Write("0"+tc);
        } else {
            Console.Write(tc);
        }
    }
}