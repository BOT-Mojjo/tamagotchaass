using System;
using System.Collections.Generic;

class tama{
    int hunger = 0;
    int bored = 0;
    bool alive = true;
    string name = "temp";
    List<string> words = new List<string>();
    int[] lastPrnt = new int[] {20,20};
    Random gen = new Random();
    int dReason = 0;
    public (bool onOff, bool hunger, bool bored) debug;
    public tama(){
        debug.onOff = false;
    }

    public void GiveName(){
        name = Console.ReadLine();
    }

    void PrintName(){
        Console.WriteLine(name);
    }

    public void PrntSts((int Left, int Top) cursor){
        Console.SetCursorPosition(cursor.Left, cursor.Top);
        prntHunger();
        Console.WriteLine();
        prntBored();
        Console.WriteLine();



        void prntHunger(){
            int ii = hunger/10;
            if(lastPrnt[0] != ii){
            Console.Write("Hunger:  ");
                for(int i = 0; i < 10; i++){
                    if(ii > i){
                        Console.Write("█");
                    } else {
                        Console.Write("▒");
                    }
                }
            }
            lastPrnt[0] = ii;
            if(debug.onOff == true){
                Console.SetCursorPosition(cursor.Left+19, cursor.Top);
                Console.Write(" "+hunger+" "+lastPrnt[0]+" "+debug.hunger);
            }
        }
        void prntBored(){
            int ii = bored/10;
            if(lastPrnt[1] != ii){
            Console.Write("Boredom: ");
                for(int i = 0; i < 10; i++){
                    if(ii > i){
                        Console.Write("█");
                    } else {
                        Console.Write("▒");
                    }
                }
            }
            lastPrnt[1] = ii;
            if(debug.onOff == true){
                Console.SetCursorPosition(cursor.Left+19, cursor.Top+1);
                Console.Write(" "+bored+" "+lastPrnt[1]+" "+debug.bored);
            }
        }
    }

    public void update(){
        if(hunger == 100){
            alive = false;
            dReason = 1;
        }else if(bored == 100){
            alive = false;
            dReason = 2;
        } else {
            debug.hunger = false;
            debug.bored = false;
            if(gen.Next(0,10) < 1){
                hunger++;
                debug.hunger = true;
            }
            if(gen.Next(0,10) < 1){
                bored++;
                debug.bored = true;
            }
        }
    }

    public void Feed(){
        hunger = hunger - 10;
        if(hunger < 0) hunger = 0;
        printMisc(new string[] {"You fed " + name,""});
    }

    public void Play(){
        bored = bored - 10;
        if(bored < 0) bored = 0;
        printMisc(new string[] {"You played with " + name,""});
    }

    public void printMisc(string[] text){
        (int, int) cursorCahce = Console.GetCursorPosition();
        Console.SetCursorPosition(0,5);
        Console.Write(text[0]);
        Console.WriteLine();
        for(int i = 0; i < text[1].Length; i++) Console.Write(text[1][i]);
        Console.SetCursorPosition(cursorCahce.Item1, cursorCahce.Item2);
    }

}