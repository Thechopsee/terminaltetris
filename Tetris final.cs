using System;
using System.Data;
using System.Threading;


namespace Tetris{
    class Tetris{
        struct point {
            public int x;
            public int y;
            public point(int x, int y){
                this.x = x;
                this.y = y;
            }
        };
               
        abstract class Shapes{
            public
            point[] tvar = new point[4];
            public bool stop = false;
            
            public Shapes(){ }
            public virtual void fall(point[] tvar, char[,] board, int board_size){
                Check(board_size, board);
                if (stop == false){
                    for (int i = 0; i < 4; i++){
                        tvar[i].x++;
                    }
                }
            }

            public void Move(point[] tvar, char[,] board, int board_size, char smer){
                bool check = false;
                if (smer == 'r'){
                    if (stop == false){
                        for (int i = 0; i < 4; i++){
                            if (tvar[i].y + 1 >= board_size){ 
                                check = true; 
                            }
                        }
                        if (check == false){
                            for (int i = 0; i < 4; i++){
                                tvar[i].y++;
                            }
                        }
                    }
                }
                else{
                    if (stop == false){
                        for (int i = 0; i < 4; i++){
                            if (tvar[i].y - 1 <= 0){
                                check = true; 
                            }
                        }
                        if (check == false){
                            for (int i = 0; i < 4; i++){
                                tvar[i].y--;
                            }
                        }
                    }
                }
            }
                  
            public virtual void Check(int board_size,char[,] board){
                for (int i = 0; i < 2; i++){
                    if (tvar[i].x + 1 >= board_size || board[tvar[i].x + 1, tvar[i].y] == ' '){
                        stop = true;
                        break;
                    }
                }
            }
        }
            
            
        class shape_S : Shapes{
            public
            shape_S(){
                point jedna = new point(0, 9);
                point dva = new point(0, 10);
                point tri = new point(1, 9);
                point ctyri = new point(1, 10);
                this.tvar[0] = tri;
                this.tvar[1] = ctyri;
                this.tvar[2] = jedna;
                this.tvar[3] = dva;                
            }         
        }
        
        class shape_ : Shapes{
            public
            shape_(){
                point jedna = new point(0, 9);
                point dva = new point(0, 10);
                point tri = new point(0, 11);
                point ctyri = new point(0, 12);
                this.tvar[2] = jedna;
                this.tvar[3] = dva;
                this.tvar[0] = tri;
                this.tvar[1] = ctyri;              
            }

            public override void Check(int board_size, char[,] board){
                for (int i = 0; i < 4; i++){
                    if (tvar[i].x + 1 >= board_size || board[tvar[i].x + 1, tvar[i].y] == ' '){
                        stop = true;
                    }
                }
            }         
        }

        class shape_T : Shapes{
            public
            shape_T(){
                point jedna = new point(0, 10);
                point dva = new point(1, 9);
                point tri = new point(1, 10);
                point ctyri = new point(1, 11);
                this.tvar[3] = jedna;
                this.tvar[0] = dva;
                this.tvar[1] = tri;
                this.tvar[2] = ctyri;               
            }
            public override void Check(int board_size, char[,] board){
                for (int i = 0; i < 3; i++){
                    if (tvar[i].x + 1 >= board_size || board[tvar[i].x + 1, tvar[i].y] == ' '){
                        stop = true;
                    }
                }
            }          
        }


        class shape_L : Shapes{
            public
            shape_L(){
                point jedna = new point(0, 10);
                point dva = new point(0, 9);
                point tri = new point(1, 9);
                point ctyri = new point(2, 9);
                this.tvar[0] = jedna;
                this.tvar[1] = ctyri;
                this.tvar[2] = dva;
                this.tvar[3] = tri;    
            }
        }

        class shape_L_Reverse : Shapes{
            public
            shape_L_Reverse(){
                point jedna = new point(0,9);
                point dva = new point(0, 10);
                point tri = new point(1, 10);
                point ctyri = new point(2, 10);
                this.tvar[0] = jedna;
                this.tvar[1] = ctyri;
                this.tvar[2] = dva;
                this.tvar[3] = tri;                            
            }
        }


        class shape_Z : Shapes{
            public
            shape_Z(){
                point jedna = new point(0, 10);
                point dva = new point(1, 10);
                point tri = new point(1, 9);
                point ctyri = new point(2, 9);
                this.tvar[0] = tri;
                this.tvar[1] = ctyri;
                this.tvar[3] = jedna;
                this.tvar[2] = dva;     
            }
        }

        class shape_Z_Reverse : Shapes{
            public
            shape_Z_Reverse(){
                point jedna = new point(0, 9);
                point dva = new point(1, 9);
                point tri = new point(1, 10);
                point ctyri = new point(2, 10);
                this.tvar[0] = tri;
                this.tvar[1] = ctyri;
                this.tvar[3] = jedna;
                this.tvar[2] = dva;         
            }
        }

        static void Draw_board(char[,] board, int board_size){
            Console.Clear();
            for (int i = 0; i < board_size; i++){
                for (int j = 0; j < board_size; j++){
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Clear_board(char[,] board, int board_size){
            for (int i = 0; i < board_size; i++){
                for (int j = 0; j < board_size; j++){
                    board[i, j] = '\u2588';
                }
            }
        }

        static void Clear_shape(point[] tmp, char[,] board, int board_size){
            for (int i = 0; i < 4; i++){
                if (tmp[i].x < board_size || tmp[i].y < board_size){
                    board[tmp[i].x, tmp[i].y] = '\u2588';
                }
            }
        }

        static void Draw_tvar(char[,] board, int board_size, point[] tvar){
            for (int n = 0; n < 4; n++){
                for (int i = 0; i < board_size; i++){
                    for (int j = 0; j < board_size; j++){
                        if (tvar[n].x == i && tvar[n].y == j){
                            board[i, j] = ' ';
                        }
                    }
                }
            }
        }

        static void random_shape(Shapes[] pole){
            Random rnd = new Random();
            int shape;

            shape = rnd.Next(1, 8);
            if (shape == 1){
                pole[0] = new shape_S();
            }
            if (shape == 2){
                pole[0] = new shape_();
            }
            if (shape == 3){
                pole[0] = new shape_T();
            }
            if (shape == 4){
                pole[0] = new shape_L();
            }
            if (shape == 5){
                pole[0] = new shape_L_Reverse();
            }
            if (shape == 6){
                pole[0] = new shape_Z();
            }
            if (shape == 7){
                pole[0] = new shape_Z_Reverse();
            }
        }


        static void Main(string[] args){        
            const int board_size = 20;
            char[,] board = new char[board_size, board_size];       

            Shapes[] pole = new Shapes[1];
            random_shape(pole);

            Clear_board(board, board_size);
            Draw_tvar(board, board_size, pole[0].tvar);
            Draw_board(board, board_size);
            
            while (true){
                Thread.Sleep(1000);
                Clear_shape(pole[0].tvar, board, board_size);

                if (Console.KeyAvailable){
                    ConsoleKeyInfo info = Console.ReadKey();
                    if (info.Key == ConsoleKey.RightArrow){                        
                        pole[0].Move(pole[0].tvar,board,board_size,'r');                 
                    }
                    if (info.Key == ConsoleKey.LeftArrow){                        
                         pole[0].Move(pole[0].tvar, board, board_size,'l');          
                    }
                }

                pole[0].fall( pole[0].tvar, board, board_size);

                Draw_tvar(board, board_size, pole[0].tvar);
                Draw_board(board, board_size);

                if (pole[0].stop == true){
                    random_shape(pole);                      
                }                                 
            }
        }
    }
}
